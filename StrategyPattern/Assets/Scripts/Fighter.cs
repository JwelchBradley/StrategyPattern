/*
 * (Jacob Welch)
 * (Fighter)
 * (StrategyPattern)
 * (Description: A class with the flash and dash abilities.)
 */

public class Fighter : PlayerClass
{

    #region Functions
    /// <summary>
    /// Adds all of the abilities that are possessed by this class to the player's gameobject.
    /// </summary>
    private void Awake()
    {
        classAbilities = new Ability[]
        {
            gameObject.AddComponent<Flash>(),
            gameObject.AddComponent<Dash>()
        };
    }
    #endregion
}
