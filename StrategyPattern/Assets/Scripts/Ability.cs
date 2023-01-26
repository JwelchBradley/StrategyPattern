/*
 * (Jacob Welch)
 * (Ability)
 * (StrategyPattern)
 * (Description: An abstract class that holds a funciton for performing abilities.)
 */
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    #region Functions
    /// <summary>
    /// Performs the funcitonality of this ability.
    /// </summary>
    public abstract void PerformAbility();
    #endregion
}
