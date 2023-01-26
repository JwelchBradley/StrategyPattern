/*
 * (Jacob Welch)
 * (Invincible)
 * (StrategyPattern)
 * (Description: An ability that makes the user invincible.)
 */
using System.Collections;
using UnityEngine;

public class Invincible : Ability
{
    #region Fields
    /// <summary>
    /// The length of time the user will stay invincible.
    /// </summary>
    private const float invincibleDuration = 3;

    // These were ommitted from the UML as they are not important
    private SpriteRenderer sr;
    private Coroutine invincibleRoutine;
    #endregion

    #region Functions
    /// <summary>
    /// Gets components.
    /// </summary>
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Makes the user invincible for a short duration.
    /// </summary>
    public override void PerformAbility()
    {
        if (invincibleRoutine != null) StopCoroutine(invincibleRoutine);

        invincibleRoutine = StartCoroutine(StayInvincible());
    }

    /// <summary>
    /// A routine for keeping the user invincible until the duration ends.
    /// </summary>
    /// <returns></returns>
    private IEnumerator StayInvincible()
    {
        sr.color = Color.cyan;

        yield return new WaitForSeconds(invincibleDuration);

        sr.color = Color.white;
        invincibleRoutine = null;
    }

    /// <summary>
    /// Sets the users color back to white when this ability is no longer active.
    /// </summary>
    private void OnDestroy()
    {
        sr.color = Color.white;
    }
    #endregion
}
