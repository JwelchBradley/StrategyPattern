/*
 * (Jacob Welch)
 * (PlayerController)
 * (StrategyPattern)
 * (Description: The controller for all actions the player can take. Handles broad inputs rather than
 * specific functionalities of those actions.)
 */
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The avaiable classes that the player can become.
    /// </summary>
    private Type[] classes = new Type[] { typeof(Tank), typeof(Fighter) };

    // Components
    private PlayerClass playersClass;
    private Rigidbody2D rb;

    /// <summary>
    /// The speed of the player.
    /// </summary>
    private const float speed = 5;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        playersClass = gameObject.AddComponent<Tank>();
        rb = GetComponent<Rigidbody2D>();
    }

    #region Input
    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        ChangeClass();
        LevelUp();
        PerformAbility();
    }

    /// <summary>
    /// Allows the player to change which class they are currently using.
    /// </summary>
    private void ChangeClass()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeClass(classes[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeClass(classes[1]);
        }
    }

    /// <summary>
    /// Accepts input to level up the players current class (effectively changes their ability).
    /// </summary>
    private void LevelUp()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            playersClass.LevelUp();
        }
    }

    /// <summary>
    /// Uses the currently active ability the player can use.
    /// </summary>
    private void PerformAbility()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playersClass.PerformAbility();
        }
    }
    #endregion

    /// <summary>
    /// Updates the game once every fixed update (movement is handled in here for rigidbody updates).
    /// </summary>
    private void FixedUpdate()
    {
        MovePlayer();
    }

    /// <summary>
    /// Sets the player's velocity (tbh too lazy to make a good movement funciton). 
    /// </summary>
    private void MovePlayer()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        rb.velocity = Vector2.ClampMagnitude((new Vector2(horizontal, vertical)*speed), speed);
    }

    /// <summary>
    /// Changes the players currently active class.
    /// </summary>
    /// <param name="newClass">The new class the player wants to become.</param>
    private void ChangeClass(Type newClass)
    {
        if(newClass != playersClass.GetType())
        {
            Destroy(playersClass);
            playersClass = (PlayerClass)gameObject.AddComponent(newClass);
        }
    }
    #endregion
}
