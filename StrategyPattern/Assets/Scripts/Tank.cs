/*
 * (Jacob Welch)
 * (Tank)
 * (StrategyPattern)
 * (Description: A class with the shield and invincible abilities.)
 */

public class Tank : PlayerClass
{
    #region Functions
    /// <summary>
    /// Adds all of the abilities that are possessed by this class to the player's gameobject.
    /// </summary>
    private void Awake()
    {
        classAbilities = new Ability[] 
        { 
            gameObject.AddComponent<Shield>(),
            gameObject.AddComponent<Invincible>()
        };
    }
    #endregion
}
