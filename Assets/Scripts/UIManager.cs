using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private TMP_Text textPlayerHealth;
    [SerializeField] private TMP_Text textPlayerDamage;
    [SerializeField] private TMP_Text textPlayerResistance;
    [SerializeField] private TMP_Text textPlayerSpeed;
    [SerializeField] private TMP_Text textPlayerCounter;
    [SerializeField] private TMP_Text textPlayerCombo;
    [SerializeField] private TMP_Text textPlayerFreeze;
    [SerializeField] private TMP_Text textPlayerFire;

    [Header("Coins")]
    [SerializeField] private TMP_Text textGold;
    [SerializeField] private TMP_Text textGems;
    [SerializeField] private TMP_Text textHourglass;

    [Header("UI")]
    [SerializeField] public GameObject panelEquipOrSell;
    [SerializeField] public Button buttonEquip;
    [SerializeField] public Button buttonSell;

    [Header("Generated New Item Stats UI")]
    [SerializeField] private TMP_Text textNewItemHealth;
    [SerializeField] private TMP_Text textNewItemDamage;
    [SerializeField] private TMP_Text textNewItemResistance;
    [SerializeField] private TMP_Text textNewItemSpeed;
    [SerializeField] public TMP_Text textNewItemExtraBuffStat1;
    [SerializeField] public TMP_Text textNewItemExtraBuffStat2;
    [SerializeField] public TMP_Text textNewItemExtraBuffName1;
    [SerializeField] public TMP_Text textNewItemExtraBuffName2;

    [Header("Generated Equipped item Stats UI")]
    [SerializeField] private TMP_Text textExistingItemHealth;
    [SerializeField] private TMP_Text textExistingItemDamage;
    [SerializeField] private TMP_Text textExistingItemResistance;
    [SerializeField] private TMP_Text textExistingItemSpeed;
    [SerializeField] public TMP_Text textExistingItemExtraBuffStat1;
    [SerializeField] public TMP_Text textExistingItemExtraBuffStat2;
    [SerializeField] public TMP_Text textExistingItemExtraBuffName1;
    [SerializeField] public TMP_Text textExistingItemExtraBuffName2;


    [Header("Generated Item Names,Rarities,Levels,etc...")]
    [SerializeField] private TMP_Text textExistingItemLvl;
    [SerializeField] private TMP_Text textNewItemLvl;
    [SerializeField] private TMP_Text textExistingItemRarity;
    [SerializeField] private TMP_Text textNewItemRarity;
    [SerializeField] private TMP_Text textExistingItemType;
    [SerializeField] private TMP_Text textNewItemType;

    [Header("Equipped Item text Level")]
    [SerializeField] private TMP_Text textPlayerEquippedItemWandLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemHeadwearLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemOutfitLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemScrollLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemHandwearLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemRingLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemNecklesLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemBootsLevel;

    [Header("Equipped Item Image Rarity")]
    [SerializeField] private Image imagePlayerEquippedItemWandRarity;
    [SerializeField] private Image imagePlayerEquippedItemHeadwearRarity;
    [SerializeField] private Image imagePlayerEquippedItemOutfitRarity;
    [SerializeField] private Image imagePlayerEquippedItemScrollRarity;
    [SerializeField] private Image imagePlayerEquippedItemHandwearRarity;
    [SerializeField] private Image imagePlayerEquippedItemRingRarity;
    [SerializeField] private Image imagePlayerEquippedItemNecklesRarity;
    [SerializeField] private Image imagePlayerEquippedItemBootsRarity;

    [Header("Equipped Item Image Sprites")]
    [SerializeField] private Image imagePlayerEquippedItemWandSprite;
    [SerializeField] private Image imagePlayerEquippedItemHeadwearSprite;
    [SerializeField] private Image imagePlayerEquippedItemOutfitSprite;
    [SerializeField] private Image imagePlayerEquippedItemScrollSprite;
    [SerializeField] private Image imagePlayerEquippedItemHandwearSprite;
    [SerializeField] private Image imagePlayerEquippedItemRingSprite;
    [SerializeField] private Image imagePlayerEquippedItemNecklesSprite;
    [SerializeField] private Image imagePlayerEquippedItemBootsSprite;

    [Header("Generated items Image Rarity and Sprites")]
    [SerializeField] private Image imageExistingItemRarity;
    [SerializeField] private Image imageNewItemRarity;
    [SerializeField] private Image imageExistingItemSprite;
    [SerializeField] private Image imageNewItemSprite;

    [Header("Rarity sprites")]
    [SerializeField] private Sprite spriteCommon;
    [SerializeField] private Sprite spriteUncommon;
    [SerializeField] private Sprite spriteRare;
    [SerializeField] private Sprite spriteEpic;
    [SerializeField] private Sprite spriteLegendary;
    [SerializeField] private Sprite spriteMythic;
    [SerializeField] private Sprite spriteAncient;
    [SerializeField] private Sprite spriteGodly;

    [Header("Wand Sprites")]    
    [SerializeField] private Image spriteWand1;
    [SerializeField] private Image spriteWand2;
    [SerializeField] private Image spriteWand3;
    [SerializeField] private Image spriteWand4;
    [SerializeField] private Image spriteWand5;

    [Header("Headwear Sprites")]
    [SerializeField] private Image spriteHeadwear1;
    [SerializeField] private Image spriteHeadwear2;
    [SerializeField] private Image spriteHeadwear3;
    [SerializeField] private Image spriteHeadwear4;
    [SerializeField] private Image spriteHeadwear5;

    [Header("Outfit Sprites")]
    [SerializeField] private Image spriteOutfit1;
    [SerializeField] private Image spriteOutfit2;
    [SerializeField] private Image spriteOutfit3;
    [SerializeField] private Image spriteOutfit4;
    [SerializeField] private Image spriteOutfit5;

    [Header("Scroll Sprites")]
    [SerializeField] private Image spriteScroll1;
    [SerializeField] private Image spriteScroll2;
    [SerializeField] private Image spriteScroll3;
    [SerializeField] private Image spriteScroll4;
    [SerializeField] private Image spriteScroll5;

    [Header("Handwear Sprites")]
    [SerializeField] private Image spriteHandwear1;
    [SerializeField] private Image spriteHandwear2;
    [SerializeField] private Image spriteHandwear3;
    [SerializeField] private Image spriteHandwear4;
    [SerializeField] private Image spriteHandwear5;

    [Header("Ring Sprites")]
    [SerializeField] private Image spriteRing1;
    [SerializeField] private Image spriteRing2;
    [SerializeField] private Image spriteRing3;
    [SerializeField] private Image spriteRing4;
    [SerializeField] private Image spriteRing5;

    [Header("Boots Sprites")]
    [SerializeField] private Image spriteBoots1;
    [SerializeField] private Image spriteBoots2;
    [SerializeField] private Image spriteBoots3;
    [SerializeField] private Image spriteBoots4;
    [SerializeField] private Image spriteBoots5;

    [Header("Neckles Sprites")]
    [SerializeField] private Image spriteNeckles1;
    [SerializeField] private Image spriteNeckles2;
    [SerializeField] private Image spriteNeckles3;
    [SerializeField] private Image spriteNeckles4;
    [SerializeField] private Image spriteNeckles5;


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

    public void UpdateAllMainUI()
    {
        // Main UI Update
        UpdatePlayerTextStatsCoin();
        UpdatePlayerTextItemLevel();

        // Making sure that the generated ExtraBuffs dont show up when they arent supposed to.
        textExistingItemExtraBuffName1.enabled = false;
        textExistingItemExtraBuffStat1.enabled = false;
        textNewItemExtraBuffName1.enabled = false;
        textNewItemExtraBuffStat1.enabled = false;
        textExistingItemExtraBuffName2.enabled = false;
        textExistingItemExtraBuffStat2.enabled = false;
        textNewItemExtraBuffName2.enabled = false;
        textNewItemExtraBuffStat2.enabled = false;
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
        // For rare and epic items, generate additional attributes
        if (newItem.itemRarity == ItemRarity.Rare || newItem.itemRarity == ItemRarity.Epic)
        {
            textNewItemExtraBuffName1.enabled = true;
            textNewItemExtraBuffStat1.enabled = true;
            if (newItem.freezeChanceBonus.ToString() != null)
            {
                textNewItemExtraBuffName1.text = "FRZ";
                textNewItemExtraBuffStat1.text = newItem.freezeChanceBonus.ToString();
            }
            if (newItem.fireChanceBonus.ToString() != null)
            {
                textNewItemExtraBuffName1.text = "FIRE";
                textNewItemExtraBuffStat1.text = newItem.fireChanceBonus.ToString();
            }
            if (newItem.comboChanceBonus.ToString() != null)
            {
                textNewItemExtraBuffName1.text = "CMB";
                textNewItemExtraBuffStat1.text = newItem.comboChanceBonus.ToString();
            }
            if (newItem.counterChanceBonus.ToString() != null)
            {
                textNewItemExtraBuffName1.text = "CTR";
                textNewItemExtraBuffStat1.text = newItem.counterChanceBonus.ToString();
            }
        }
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
        // Additional stat
        // For rare and epic items, generate additional attributes
        if (main.equipmentSlots[existingItemSlotIndex].itemRarity == ItemRarity.Rare || main.equipmentSlots[existingItemSlotIndex].itemRarity == ItemRarity.Epic)
        {
            textExistingItemExtraBuffName1.enabled = true;
            textExistingItemExtraBuffStat1.enabled = true;
            if (main.equipmentSlots[existingItemSlotIndex].freezeChanceBonus.ToString() != null)
            {
                textExistingItemExtraBuffName1.text = "FRZ";
                textExistingItemExtraBuffStat1.text = main.equipmentSlots[existingItemSlotIndex].freezeChanceBonus.ToString();
            }
            if (main.equipmentSlots[existingItemSlotIndex].fireChanceBonus.ToString() != null)
            {
                textExistingItemExtraBuffName1.text = "FIRE";
                textExistingItemExtraBuffStat1.text = main.equipmentSlots[existingItemSlotIndex].fireChanceBonus.ToString();
            }
            if (main.equipmentSlots[existingItemSlotIndex].comboChanceBonus.ToString() != null)
            {
                textExistingItemExtraBuffName1.text = "CMB";
                textExistingItemExtraBuffStat1.text = main.equipmentSlots[existingItemSlotIndex].comboChanceBonus.ToString();
            }
            if (main.equipmentSlots[existingItemSlotIndex].counterChanceBonus.ToString() != null)
            {
                textExistingItemExtraBuffName1.text = "CTR";
                textExistingItemExtraBuffStat1.text = main.equipmentSlots[existingItemSlotIndex].counterChanceBonus.ToString();
            }
        }
        /*textExistingItemCombo.text = main.equipmentSlots[existingItemSlotIndex].comboChanceBonus.ToString();
        textExistingItemCounter.text = main.equipmentSlots[existingItemSlotIndex].counterChanceBonus.ToString();
        textExistingItemFreeze.text = main.equipmentSlots[existingItemSlotIndex].freezeChanceBonus.ToString();
        textExistingItemFire.text = main.equipmentSlots[existingItemSlotIndex].fireChanceBonus.ToString();*/
    }
    public void UpdatePlayerTextStatsCoin()
    {
        //Stats
        textPlayerDamage.text = main.damage.ToString();
        textPlayerHealth.text = main.health.ToString();
        textPlayerSpeed.text = main.speed.ToString();
        textPlayerResistance.text = main.resistance.ToString();
        textPlayerFreeze.text = main.freezeChance.ToString();
        textPlayerFire.text = main.fireChance.ToString();
        textPlayerCombo.text = main.comboChance.ToString();
        textPlayerCounter.text = main.counterChance.ToString();

        //Coins
        textGold.text = main.gold.ToString();
        textGems.text = main.gems.ToString();
        textHourglass.text = main.hourglass.ToString();
    }

    public void UpdatePlayerTextItemLevel()
    {
        textPlayerEquippedItemWandLevel.text = "Lv. " + main.equipmentSlots[0].itemLevel.ToString();
        textPlayerEquippedItemHeadwearLevel.text = "Lv. " + main.equipmentSlots[1].itemLevel.ToString();
        textPlayerEquippedItemOutfitLevel.text = "Lv. " + main.equipmentSlots[2].itemLevel.ToString();
        textPlayerEquippedItemScrollLevel.text = "Lv. " + main.equipmentSlots[3].itemLevel.ToString();
        textPlayerEquippedItemHandwearLevel.text = "Lv. " + main.equipmentSlots[4].itemLevel.ToString();
        textPlayerEquippedItemRingLevel.text = "Lv. " + main.equipmentSlots[5].itemLevel.ToString();
        textPlayerEquippedItemNecklesLevel.text = "Lv. " + main.equipmentSlots[6].itemLevel.ToString();
        textPlayerEquippedItemBootsLevel.text = "Lv. " + main.equipmentSlots[7].itemLevel.ToString();

    }
    public void UpdatePlayerItemSprites(int existingItemSlotIndex)
    {
        Image[] spritePlayerEquippedItemRarity = { imagePlayerEquippedItemWandRarity, imagePlayerEquippedItemHeadwearRarity, imagePlayerEquippedItemOutfitRarity, imagePlayerEquippedItemScrollRarity, imagePlayerEquippedItemHandwearRarity, imagePlayerEquippedItemRingRarity, imagePlayerEquippedItemNecklesRarity, imagePlayerEquippedItemBootsRarity };
        Image[] spritePlayerEquippedItemSprite = { imagePlayerEquippedItemWandSprite, imagePlayerEquippedItemHeadwearSprite, imagePlayerEquippedItemOutfitSprite, imagePlayerEquippedItemScrollSprite, imagePlayerEquippedItemHandwearSprite, imagePlayerEquippedItemRingSprite, imagePlayerEquippedItemNecklesSprite, imagePlayerEquippedItemBootsSprite };
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

        }
        /*switch (main.equipmentSlots[existingItemSlotIndex].itemType)
        {
            case ItemType.Wand:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = ;
                break;
            case ItemType.Headwear:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteHeadwear1;
                break;
            case ItemType.Outfit:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteOutfit1;
                break;
            case ItemType.Scroll:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteScroll1;
                break;
            case ItemType.Handwear:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteHandwear1;
                break;
            case ItemType.Ring:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteRing1;
                break;
            case ItemType.Necklace:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteNeckles1;
                break;
            case ItemType.Boots:
                spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spriteBoots1;
                break;
        }   */

    }
    
}
