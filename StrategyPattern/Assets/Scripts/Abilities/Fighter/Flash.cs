/*
 * (Jacob Welch)
 * (Flash)
 * (StrategyPattern)
 * (Description: A functionality for flashing the screen (and presumely enemies if they were in the game).)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : Ability
{
    #region Fields
    /// <summary>
    /// How long the flash will be on the screen.
    /// </summary>
    protected float flashDuration = 0.65f;

    /// <summary>
    /// The delay before the flash starts fading out.
    /// </summary>
    protected float flashFadeoutDelay = 0.15f;

    // These aren't listed in the UML as they arent imperative to it's design
    // These are just temporary references to values of it's implementation and thus wouldn't affect the overall
    // Way I structured these classes
    private Sprite square;
    private Color clear;
    private List<GameObject> flashes = new List<GameObject>();
    #endregion

    #region Functions
    /// <summary>
    /// Gets references and sets various fields.
    /// </summary>
    private void Awake()
    {
        square = GetComponent<SpriteRenderer>().sprite;
        clear = Color.white;
        clear.a = 0;
    }

    /// <summary>
    /// Flashes the screen and presumely enemies if they were in this game.
    /// </summary>
    public override void PerformAbility()
    {
        StartCoroutine(FlashRoutine());
    }

    /// <summary>
    /// A routine for displaying a flash on the screen. (normally I would handles this through spawning a prefab but I'm lazy).
    /// </summary>
    /// <returns></returns>
    private IEnumerator FlashRoutine()
    {
        // Spawns the flash
        var flash = new GameObject("Flash");
        flash.transform.localScale = new Vector2(100, 100);
        flashes.Add(flash);

        // Gets and sets its renderer
        var flashSR = flash.AddComponent<SpriteRenderer>();
        flashSR.sprite = square;

        // Fades out the flash
        var t = flashDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;

            var colorLerp = Mathf.InverseLerp(flashDuration - flashFadeoutDelay, 0, t);
            flashSR.color = Color.Lerp(Color.white, clear, colorLerp);

            yield return new WaitForEndOfFrame();
        }

        // Destroys the flash
        flashes.Remove(flash);
        Destroy(flash);
    }

    /// <summary>
    /// Removes flashes once this ability is no longer available.
    /// </summary>
    private void OnDestroy()
    {
        foreach(GameObject flash in flashes)
        {
            Destroy(flash);
        }
    }
    #endregion
}
