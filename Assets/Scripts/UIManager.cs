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
    [SerializeField] private TMP_Text textNewItemHealth, textNewItemDamage, textNewItemResistance, textNewItemSpeed, textNewItemCounter, textNewItemCombo, textNewItemFreeze, textNewItemFire;

    // Equipped item UI
    [SerializeField] private TMP_Text textExistingItemHealth, textExistingItemDamage, textExistingItemResistance, textExistingItemSpeed, textExistingItemCounter, textExistingItemCombo, textExistingItemFreeze, textExistingItemFire;

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
        textNewItemHealth.text = newItem.healthBonus.ToString();
        /*textNewItemDamage.text = newItem.damageBonus.ToString();
        textNewItemSpeed.text = newItem.speedBonus.ToString();
        textNewItemResistance.text = newItem.resistanceBonus.ToString();
        textNewItemCombo.text = newItem.comboChanceBonus.ToString();
        textNewItemCounter.text = newItem.counterChanceBonus.ToString();
        textNewItemFreeze.text = newItem.freezeChanceBonus.ToString();
        textNewItemFire.text = newItem.fireChanceBonus.ToString();*/
    }
    public void ShowExistingItemStatsText(int existingItemSlotIndex)
    {
        textExistingItemHealth.text = main.equipmentSlots[existingItemSlotIndex].healthBonus.ToString();
        /*textExistingItemDamage.text = main.equipmentSlots[existingItemSlotIndex].damageBonus.ToString();
        textExistingItemSpeed.text = main.equipmentSlots[existingItemSlotIndex].speedBonus.ToString();
        textExistingItemResistance.text = main.equipmentSlots[existingItemSlotIndex].resistanceBonus.ToString();
        textExistingItemCombo.text = main.equipmentSlots[existingItemSlotIndex].comboChanceBonus.ToString();
        textExistingItemCounter.text = main.equipmentSlots[existingItemSlotIndex].counterChanceBonus.ToString();
        textExistingItemFreeze.text = main.equipmentSlots[existingItemSlotIndex].freezeChanceBonus.ToString();
        textExistingItemFire.text = main.equipmentSlots[existingItemSlotIndex].fireChanceBonus.ToString();*/
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
