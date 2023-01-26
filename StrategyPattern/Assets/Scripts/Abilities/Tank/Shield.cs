/*
 * (Jacob Welch)
 * (Shield)
 * (StrategyPattern)
 * (Description: Allows the player to bring out an equippable shield.)
 */
using System.Collections;
using UnityEngine;

public class Shield : Ability
{
    #region Fields
    // None of these are really imperative to the design of the UML so they were ommitted from it
    private Coroutine shieldRoutine;
    private GameObject shield;
    private Sprite square;
    private const float shieldDist = 1.5f;
    #endregion

    #region Functions
    /// <summary>
    /// Gets components.
    /// </summary>
    private void Awake()
    {
        square = GetComponent<SpriteRenderer>().sprite;
    }

    /// <summary>
    /// Spawns a shield in front of the player.
    /// </summary>
    public override void PerformAbility()
    {
        if (shieldRoutine != null) StopCoroutine(shieldRoutine);

        shieldRoutine = StartCoroutine(KeepUpShield());
    }

    /// <summary>
    /// Keeps the shield up for as long as the player holds space.
    /// </summary>
    /// <returns></returns>
    private IEnumerator KeepUpShield()
    {
        // Spawns the shield
        shield = new GameObject("Shield");
        var shieldSR = shield.AddComponent<SpriteRenderer>();
        shieldSR.sprite = square;
        shieldSR.color = Color.cyan;

        shield.transform.localScale = new Vector3(1, 3, 1);
        Vector2 movementVector = Vector2.up;

        // Keeps the shield in front of where the player is moving towards
        while (Input.GetKey(KeyCode.Space))
        {
            // Determine player movement direction
            var horizontal = Input.GetAxisRaw("Horizontal");
            var vertical = Input.GetAxisRaw("Vertical");
            if (horizontal != 0 || vertical != 0) movementVector = Vector2.ClampMagnitude(new Vector2(horizontal, vertical), 1);

            // Position and rotate shield
            shield.transform.position = (movementVector * shieldDist) + (Vector2)transform.position;
            shield.transform.right = movementVector;

            yield return new WaitForEndOfFrame();
        }

        // Remove shield
        Destroy(shield);
        shieldRoutine = null;
    }

    /// <summary>
    /// Removes the shield if the user changes classes.
    /// </summary>
    private void OnDestroy()
    {
        if(shield != null)
        Destroy(shield);
    }
    #endregion
}
