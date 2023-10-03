using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textPlayerHealth, textPlayerDamage, textPlayerResistance, textPlayerSpeed, textPlayerCounter, textPlayerCombo, textPlayerFreeze, textPlayerFire;

    // UI
    [SerializeField] public GameObject equipOrSellPanel;
    [SerializeField] public Button equipButton;
    [SerializeField] public Button sellButton;

    // Generated Item UI
    [SerializeField] private TMP_Text newHealthText;

    // Equipped item UI
    [SerializeField] private TMP_Text existingHealthText;

    private Main main;

    // Initialize itemGenerator in Start or Awake
    private void Awake()
    {
        // Try to find the ItemGenerator component on the Player GameObject
        main = GetComponent<Main>();

        // If it's still null, create and attach the component
        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
    }
    public void ShowNewItemStatsText(Item newItem)
    {
        newHealthText.text = newItem.healthBonus.ToString();
    }
    public void ShowExistingItemStatsText()
    {

    }
    public void UpdatePlayerTextStats()
    {
        textPlayerDamage.text = main.damage.ToString();
        textPlayerHealth.text = main.health.ToString();
        textPlayerSpeed.text = main.speed.ToString();
        textPlayerResistance.text = main.resistance.ToString();
        textPlayerFreeze.text = main.freezeChance.ToString();
        textPlayerFire.text = main.fireChance.ToString();
        textPlayerCombo.text = main.comboChance.ToString();
        textPlayerCounter.text = main.counterChance.ToString(); 
    }
    
}
