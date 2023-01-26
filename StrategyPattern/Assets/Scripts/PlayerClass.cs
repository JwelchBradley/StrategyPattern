/*
 * (Jacob Welch)
 * (PlayerClass)
 * (StrategyPattern)
 * (Description: A base class for all player class that the user can be. Handles leveling up funcitonality
 * but does not define the abilities that the class can possess.)
 */
using System;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour
{
    #region Fields
    // References to the characters abilities
    protected Ability[] classAbilities = new Ability[0];
    protected Ability activeAbility;
    #endregion

    #region Functions
    /// <summary>
    /// Initializes the classes first level.
    /// </summary>
    private void Start()
    {
        LevelUp();
    }

    /// <summary>
    /// Sets the ability of the class to be the current levels ability.
    /// </summary>
    public void LevelUp()
    {
        var nextAbilityIndex = 0;

        if (activeAbility != null) nextAbilityIndex = Array.IndexOf(classAbilities, activeAbility) + 1;

        if (nextAbilityIndex < classAbilities.Length)
        {
            activeAbility = classAbilities[nextAbilityIndex];
            UIManager.DisplayNewAbility(activeAbility.GetType().Name, nextAbilityIndex+1, GetType().Name);
        }
    }

    /// <summary>
    /// Performs the action of the currently active ability.
    /// </summary>
    public void PerformAbility()
    {
        activeAbility.PerformAbility();
    }

    /// <summary>
    /// Removes the extra Abilities when this class is no longer active.
    /// </summary>
    private void OnDestroy()
    {
        foreach(Ability ability in classAbilities)
        {
            Destroy(ability);
        }
    }
    #endregion
}
