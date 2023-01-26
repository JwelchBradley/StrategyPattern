/*
 * (Jacob Welch)
 * (Dash)
 * (StrategyPattern)
 * (Description: Dashes the user in the direction that they are moving.)
 */
using UnityEngine;

public class Dash : Ability
{
    #region Fields
    /// <summary>
    /// The distance that the user dashes forward.
    /// </summary>
    private const float dashDist = 3;

    // This was ommitted from the UML as it is not important
    private Rigidbody2D rb;
    #endregion

    #region Functions
    /// <summary>
    /// Gets components.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Dashes the user forward.
    /// </summary>
    public override void PerformAbility()
    {
        // Gets user input
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        
        Vector2 movementVector = Vector2.up;
        if(horizontal != 0 || vertical != 0) movementVector = Vector2.ClampMagnitude(new Vector2(horizontal, vertical), 1);
        
        rb.MovePosition((Vector2)transform.position + (movementVector*dashDist));
    }
    #endregion
}
