/*
 * (Jacob Welch)
 * (UIManager)
 * (StrategyPattern)
 * (Description: Manages the UI elements that are in the game and their functionalities.)
 */
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Fields
    /// <summary>
    /// The text that displays the current ability, class, and level.
    /// </summary>
    private static TextMeshProUGUI AbilityText;

    [Tooltip("The text that displays the current ability, class, and level")]
    [SerializeField] private TextMeshProUGUI abilityText;
    #endregion

    #region Functions
    /// <summary>
    /// Sets static reference to the ability text.
    /// </summary>
    private void Awake()
    {
        AbilityText = abilityText;
    }

    /// <summary>
    /// Changes the currently displayed ability, class and level.
    /// </summary>
    /// <param name="newAbilityText"></param>
    /// <param name="level"></param>
    /// <param name="playerClass"></param>
    public static void DisplayNewAbility(string newAbilityText, int level, string playerClass)
    {
        if (AbilityText == null) return;

        AbilityText.text = playerClass + " lvl " + level + " with " + newAbilityText + " ability";
    }
    #endregion
}
