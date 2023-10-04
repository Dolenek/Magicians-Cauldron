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

    // Generated Item Stats UI
    [SerializeField] private TMP_Text textNewItemHealth, textNewItemDamage, textNewItemResistance, textNewItemSpeed, textNewItemExtraBuffStat1, textNewItemExtraBuffStat2, textNewItemExtraBuffName1, textNewItemExtraBuffName2;

    // Equipped item Stats UI
    [SerializeField] private TMP_Text textExistingItemHealth, textExistingItemDamage, textExistingItemResistance, textExistingItemSpeed, textExistingItemExtraBuffStat1, textExistingItemExtraBuffStat2, textExistingItemExtraBuffName1, textExistingItemExtraBuffName2;

    // Item Names,Rarities,Levels,etc...
    [SerializeField] private TMP_Text textExistingItemLvl, textNewItemLvl;
    [SerializeField] private TMP_Text textExistingItemRarity, textNewItemRarity;
    [SerializeField] private TMP_Text textExistingItemType, textNewItemType;

    // Item Sprites
    //Rarity
    [SerializeField] private Sprite spriteCommon, spriteUncommon, spriteRare, spriteEpic, spriteLegendary;
    //Item sprites
    

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
    public void ShowNewItemText(Item newItem)
    {
        // Item Sprites
        // Set rarity sprite based on item rarity
        switch (newItem.itemRarity)
        {
            case ItemRarity.Common:
                newItem.spriteRarity = spriteCommon;
                break;
            case ItemRarity.Uncommon:
                newItem.spriteRarity = spriteUncommon;
                break;
            case ItemRarity.Rare:
                newItem.spriteRarity = spriteRare;
                break;
            case ItemRarity.Epic:
                newItem.spriteRarity = spriteEpic;
                break;
            case ItemRarity.Legendary:
                newItem.spriteRarity = spriteLegendary;
                break;
        }
        // Item UI
        textNewItemLvl.text = "Lv. " + newItem.itemLevel.ToString();
        textNewItemRarity.text = "[" + newItem.itemRarity.ToString().ToUpper() + "]";
        textNewItemType.text = newItem.itemType.ToString();
        // Stats
        textNewItemHealth.text = newItem.healthBonus.ToString();
        textNewItemDamage.text = newItem.damageBonus.ToString();
        textNewItemSpeed.text = newItem.speedBonus.ToString();
        textNewItemResistance.text = newItem.resistanceBonus.ToString();
        /*textNewItemCombo.text = newItem.comboChanceBonus.ToString();
        textNewItemCounter.text = newItem.counterChanceBonus.ToString();
        textNewItemFreeze.text = newItem.freezeChanceBonus.ToString();
        textNewItemFire.text = newItem.fireChanceBonus.ToString();*/
    }
    public void ShowExistingItemText(int existingItemSlotIndex)
    {
        // Item Sprites
        // Set rarity sprite based on item rarity
        switch (main.equipmentSlots[existingItemSlotIndex].itemRarity)
        {
            case ItemRarity.Common:
                main.equipmentSlots[existingItemSlotIndex].spriteRarity = spriteCommon;
                break;
            case ItemRarity.Uncommon:
                main.equipmentSlots[existingItemSlotIndex].spriteRarity = spriteUncommon;
                break;
            case ItemRarity.Rare:
                main.equipmentSlots[existingItemSlotIndex].spriteRarity = spriteRare;
                break;
            case ItemRarity.Epic:
                main.equipmentSlots[existingItemSlotIndex].spriteRarity = spriteEpic;
                break;
            case ItemRarity.Legendary:
                main.equipmentSlots[existingItemSlotIndex].spriteRarity = spriteLegendary;
                break;
        }
        // Item UI
        textExistingItemLvl.text = "Lv. " + main.equipmentSlots[existingItemSlotIndex].itemLevel.ToString();
        textExistingItemRarity.text = "[" + main.equipmentSlots[existingItemSlotIndex].itemRarity.ToString().ToUpper() + "]";
        textExistingItemType.text = main.equipmentSlots[existingItemSlotIndex].itemType.ToString();
        // Stats
        textExistingItemHealth.text = main.equipmentSlots[existingItemSlotIndex].healthBonus.ToString();
        textExistingItemDamage.text = main.equipmentSlots[existingItemSlotIndex].damageBonus.ToString();
        textExistingItemSpeed.text = main.equipmentSlots[existingItemSlotIndex].speedBonus.ToString();
        textExistingItemResistance.text = main.equipmentSlots[existingItemSlotIndex].resistanceBonus.ToString();
        /*textExistingItemCombo.text = main.equipmentSlots[existingItemSlotIndex].comboChanceBonus.ToString();
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
