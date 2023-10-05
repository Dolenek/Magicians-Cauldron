using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Player stats
    [SerializeField] private TMP_Text textPlayerHealth, textPlayerDamage, textPlayerResistance, textPlayerSpeed, textPlayerCounter, textPlayerCombo, textPlayerFreeze, textPlayerFire;

    // UI
    [SerializeField] public GameObject panelEquipOrSell;
    [SerializeField] public Button buttonEquip;
    [SerializeField] public Button buttonSell;

    // Generated New Item Stats UI
    [SerializeField] private TMP_Text textNewItemHealth, textNewItemDamage, textNewItemResistance, textNewItemSpeed, textNewItemExtraBuffStat1, textNewItemExtraBuffStat2, textNewItemExtraBuffName1, textNewItemExtraBuffName2;

    // Generated Equipped item Stats UI
    [SerializeField] private TMP_Text textExistingItemHealth, textExistingItemDamage, textExistingItemResistance, textExistingItemSpeed, textExistingItemExtraBuffStat1, textExistingItemExtraBuffStat2, textExistingItemExtraBuffName1, textExistingItemExtraBuffName2;

    // Generated Item Names,Rarities,Levels,etc...
    [SerializeField] private TMP_Text textExistingItemLvl, textNewItemLvl;
    [SerializeField] private TMP_Text textExistingItemRarity, textNewItemRarity;
    [SerializeField] private TMP_Text textExistingItemType, textNewItemType;

    // Equipped Item texts
    [SerializeField] private TMP_Text textPlayerEquippedItemWandLevel, textPlayerEquippedItemHeadwearLevel, textPlayerEquippedItemOutfitLevel, textPlayerEquippedItemCloakLevel, textPlayerEquippedItemHandwearLevel, textPlayerEquippedItemRingLevel, textPlayerEquippedItemNecklesLevel, textPlayerEquippedItemBootsLevel;

    // Equipped Item Sprites
    [SerializeField] private Image imagePlayerEquippedItemWandRarity, imagePlayerEquippedItemHeadwearRarity, imagePlayerEquippedItemOutfitRarity, imagePlayerEquippedItemCloakRarity, imagePlayerEquippedItemHandwearRarity, imagePlayerEquippedItemRingRarity, imagePlayerEquippedItemNecklesRarity, imagePlayerEquippedItemBootsRarity;
    [SerializeField] private Image imagePlayerEquippedItemWandSprite, imagePlayerEquippedItemHeadwearSprite, imagePlayerEquippedItemOutfitSprite, imagePlayerEquippedItemCloakSprite, imagePlayerEquippedItemHandwearSprite, imagePlayerEquippedItemRingSprite, imagePlayerEquippedItemNecklesSprite, imagePlayerEquippedItemBootsSprite;
    
    //Generated items
    [SerializeField] private Image imageExistingItemRarity, imageNewItemRarity;
    [SerializeField] private Image imageExistingItemSprite, imageNewItemSprite;
    //Rarities
    [SerializeField] private Sprite spriteCommon, spriteUncommon, spriteRare, spriteEpic, spriteLegendary, spriteMythic, spriteAncient, spriteGodly;
    //Wand
    [SerializeField] private Image[] spriteWand;
    //Headwear
    //Outfit
    //Cloak
    //Handwear
    //Ring
    //Boots
    //Neckles


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
                imageNewItemRarity.sprite = spriteCommon;
                break;
            case ItemRarity.Uncommon:
                imageNewItemRarity.sprite = spriteUncommon;
                break;
            case ItemRarity.Rare:
                imageNewItemRarity.sprite = spriteRare;
                break;
            case ItemRarity.Epic:
                imageNewItemRarity.sprite = spriteEpic;
                break;
            case ItemRarity.Legendary:
                imageNewItemRarity.sprite = spriteLegendary;
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
        if (main.equipmentSlots[existingItemSlotIndex].itemRarity != 0)
        { 
        switch (main.equipmentSlots[existingItemSlotIndex].itemRarity)
            {
            case ItemRarity.Common:
                imageExistingItemRarity.sprite = spriteCommon;
                break;
            case ItemRarity.Uncommon:
                imageExistingItemRarity.sprite = spriteUncommon;
                break;
            case ItemRarity.Rare:
                imageExistingItemRarity.sprite = spriteRare;
                break;
            case ItemRarity.Epic:
                imageExistingItemRarity.sprite = spriteEpic;
                break;
            case ItemRarity.Legendary:
                imageExistingItemRarity.sprite  = spriteLegendary;
                break;
            }
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
    public void UpdatePlayerItemSprites(int existingItemSlotIndex)
    {
        Image[] spritePlayerEquippedItemRarity = { imagePlayerEquippedItemWandRarity, imagePlayerEquippedItemHeadwearRarity, imagePlayerEquippedItemOutfitRarity, imagePlayerEquippedItemCloakRarity, imagePlayerEquippedItemHandwearRarity, imagePlayerEquippedItemRingRarity, imagePlayerEquippedItemNecklesRarity, imagePlayerEquippedItemBootsRarity };
        Image[] spritePlayerEquippedItemSprite = { imagePlayerEquippedItemWandSprite, imagePlayerEquippedItemHeadwearSprite, imagePlayerEquippedItemOutfitSprite, imagePlayerEquippedItemCloakSprite, imagePlayerEquippedItemHandwearSprite, imagePlayerEquippedItemRingSprite, imagePlayerEquippedItemNecklesSprite, imagePlayerEquippedItemBootsSprite };
        TMP_Text[] textPlayerEquippedItemLevel = { textPlayerEquippedItemWandLevel, textPlayerEquippedItemHeadwearLevel, textPlayerEquippedItemOutfitLevel, textPlayerEquippedItemCloakLevel, textPlayerEquippedItemHandwearLevel, textPlayerEquippedItemRingLevel, textPlayerEquippedItemNecklesLevel, textPlayerEquippedItemBootsLevel };
        if (main.equipmentSlots[existingItemSlotIndex] != null)
        {
            switch (main.equipmentSlots[existingItemSlotIndex].itemRarity)
            {
                case ItemRarity.Common:
                    spritePlayerEquippedItemRarity[existingItemSlotIndex].sprite = spriteCommon;
                    break;
                case ItemRarity.Uncommon:
                    spritePlayerEquippedItemRarity[existingItemSlotIndex].sprite = spriteUncommon;
                    break;
                case ItemRarity.Rare:
                    spritePlayerEquippedItemRarity[existingItemSlotIndex].sprite = spriteRare;
                    break;
                case ItemRarity.Epic:
                    spritePlayerEquippedItemRarity[existingItemSlotIndex].sprite = spriteEpic;
                    break;
                case ItemRarity.Legendary:
                    spritePlayerEquippedItemRarity[existingItemSlotIndex].sprite = spriteLegendary;
                    break;
            }

            textPlayerEquippedItemLevel[existingItemSlotIndex].text = "Lv. " + main.equipmentSlots[existingItemSlotIndex].itemLevel.ToString();
        }

    }
    
}
