using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


[DefaultExecutionOrder(-1)]
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
    [SerializeField] public GameObject panelEquipOrSellFirst;
    [SerializeField] public Button buttonEquipFirst;
    [SerializeField] public Button buttonSellFirst;

    [Header("Quests")]
    [SerializeField] public TMP_Text textQuestTitle;
    [SerializeField] public TMP_Text textQuestObjective;
    [SerializeField] public TMP_Text textQuestHourglassReward;
    [SerializeField] public Image imageQuest;

    [Header("Settings")]
    [SerializeField] private GameObject panelSettings;
    [SerializeField] private GameObject panelSettingsTapToClose;

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

    [Header("Generated New Item First Stats UI")]
    [SerializeField] private TMP_Text textNewFirstItemHealth;
    [SerializeField] private TMP_Text textNewFirstItemDamage;
    [SerializeField] private TMP_Text textNewFirstItemResistance;
    [SerializeField] private TMP_Text textNewFirstItemSpeed;
    [SerializeField] public TMP_Text textNewFirstItemExtraBuffStat1;
    [SerializeField] public TMP_Text textNewFirstItemExtraBuffStat2;
    [SerializeField] public TMP_Text textNewFirstItemExtraBuffName1;
    [SerializeField] public TMP_Text textNewFirstItemExtraBuffName2;

    [Header("Generated Item Names,Rarities,Levels,etc...")]
    [SerializeField] private TMP_Text textExistingItemLvl;
    [SerializeField] private TMP_Text textNewItemLvl;
    [SerializeField] private TMP_Text textExistingItemRarity;
    [SerializeField] private TMP_Text textNewItemRarity;
    [SerializeField] private TMP_Text textExistingItemType;
    [SerializeField] private TMP_Text textNewItemType;
    [SerializeField] private TMP_Text textNewFirstItemLvl;
    [SerializeField] private TMP_Text textNewFirstItemRarity;
    [SerializeField] private TMP_Text textNewFirstItemType;

    [Header("Equipped Item text Level")]
    [SerializeField] private TMP_Text textPlayerEquippedItemWandLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemHeadwearLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemOutfitLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemScrollLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemHandwearLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemRingLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemNecklaceLevel;
    [SerializeField] private TMP_Text textPlayerEquippedItemBootsLevel;

    [Header("Equipped Item Image Rarity")]
    [SerializeField] private Image imagePlayerEquippedItemWandRarity;
    [SerializeField] private Image imagePlayerEquippedItemHeadwearRarity;
    [SerializeField] private Image imagePlayerEquippedItemOutfitRarity;
    [SerializeField] private Image imagePlayerEquippedItemScrollRarity;
    [SerializeField] private Image imagePlayerEquippedItemHandwearRarity;
    [SerializeField] private Image imagePlayerEquippedItemRingRarity;
    [SerializeField] private Image imagePlayerEquippedItemNecklaceRarity;
    [SerializeField] private Image imagePlayerEquippedItemBootsRarity;

    [Header("Equipped Item Image Sprites")]
    [SerializeField] private Image imagePlayerEquippedItemWandSprite;
    [SerializeField] private Image imagePlayerEquippedItemHeadwearSprite;
    [SerializeField] private Image imagePlayerEquippedItemOutfitSprite;
    [SerializeField] private Image imagePlayerEquippedItemScrollSprite;
    [SerializeField] private Image imagePlayerEquippedItemHandwearSprite;
    [SerializeField] private Image imagePlayerEquippedItemRingSprite;
    [SerializeField] private Image imagePlayerEquippedItemNecklaceSprite;
    [SerializeField] private Image imagePlayerEquippedItemBootsSprite;

    [Header("Generated items Image Rarity and Sprites")]
    [SerializeField] private Image imageExistingItemRarity;
    [SerializeField] private Image imageNewItemRarity;
    [SerializeField] private Image imageExistingItemSprite;
    [SerializeField] private Image imageNewItemSprite;
    [SerializeField] private Image imageNewFirstItemSprite;
    [SerializeField] private Image imageNewFirstItemRarity;

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
    [SerializeField] public Sprite[] spritesWand;

    [Header("Headwear Sprites")]
    [SerializeField] public Sprite[] spritesHeadwear;

    [Header("Outfit Sprites")]
    [SerializeField] public Sprite[] spritesOutfit;

    [Header("Orb Sprites")]
    [SerializeField] public Sprite[] spritesOrb;

    [Header("Handwear Sprites")]
    [SerializeField] public Sprite[] spritesHandwear;

    [Header("Ring Sprites")]
    [SerializeField] public Sprite[] spritesRing;

    [Header("Boots Sprites")]
    [SerializeField] public Sprite[] spritesBoots;

    [Header("Necklace Sprites")]
    [SerializeField] public Sprite[] spritesNecklace;


    private QuestDatabase questDatabase;
    private QuestsSO questsSO;
    private Main main;

    // Initialize itemGenerator in Start or Awake
    private void Awake()
    {
        // Try to find the ItemGenerator component on the Player GameObject
        main = GetComponent<Main>();
        questDatabase = GetComponent<QuestDatabase>();
        // If it's still null, create and attach the component
        if (main == null)
            main = gameObject.AddComponent<Main>();
        if (main.currentSceneName == "MainScene")
        {
            if (questDatabase == null)
                questDatabase = gameObject.AddComponent<QuestDatabase>();
        }
    }

    public void UpdateAllMainUI()
    {
        // Main UI Update
        UpdatePlayerTextStatsCoin();
        UpdatePlayerTextItemLevel();
        UpdateQuestUI();

        // Making sure that the generated ExtraBuffs dont show up when they arent supposed to.
        textExistingItemExtraBuffName1.enabled = false;
        textExistingItemExtraBuffStat1.enabled = false;
        textNewItemExtraBuffName1.enabled = false;
        textNewItemExtraBuffStat1.enabled = false;
        textExistingItemExtraBuffName2.enabled = false;
        textExistingItemExtraBuffStat2.enabled = false;
        textNewItemExtraBuffName2.enabled = false;
        textNewItemExtraBuffStat2.enabled = false;
        textNewFirstItemExtraBuffName1.enabled = false;
        textNewFirstItemExtraBuffStat1.enabled = false;
        textNewFirstItemExtraBuffName2.enabled = false;
        textNewFirstItemExtraBuffStat2.enabled = false;

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
        switch (newItem.itemType)
        {
            case ItemType.Wand:
                imageNewItemSprite.sprite = spritesWand[newItem.itemIntSprite]; ;
                break;
            case ItemType.Headwear:
                imageNewItemSprite.sprite = spritesHeadwear[newItem.itemIntSprite];
                break;
            case ItemType.Outfit:
                imageNewItemSprite.sprite = spritesOutfit[newItem.itemIntSprite];
                break;
            case ItemType.Orb:
                imageNewItemSprite.sprite = spritesOrb[newItem.itemIntSprite];
                break;
            case ItemType.Handwear:
                imageNewItemSprite.sprite = spritesHandwear[newItem.itemIntSprite];
                break;
            case ItemType.Ring:
                imageNewItemSprite.sprite = spritesRing[newItem.itemIntSprite];
                break;
            case ItemType.Necklace:
                imageNewItemSprite.sprite = spritesNecklace[newItem.itemIntSprite];
                break;
            case ItemType.Boots:
                imageNewItemSprite.sprite = spritesBoots[newItem.itemIntSprite];
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
        // Set sprite based on item type
        if (main.equipmentSlots[existingItemSlotIndex].itemSprite != null)
        {
            switch (main.equipmentSlots[existingItemSlotIndex].itemType)
            {
                case ItemType.Wand:
                    imageExistingItemSprite.sprite = spritesWand[main.equipmentSlots[existingItemSlotIndex].itemIntSprite]; ;
                    break;
                case ItemType.Headwear:
                    imageExistingItemSprite.sprite = spritesHeadwear[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Outfit:
                    imageExistingItemSprite.sprite = spritesOutfit[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Orb:
                    imageExistingItemSprite.sprite = spritesOrb[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Handwear:
                    imageExistingItemSprite.sprite = spritesHandwear[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Ring:
                    imageExistingItemSprite.sprite = spritesRing[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Necklace:
                    imageExistingItemSprite.sprite = spritesNecklace[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Boots:
                    imageExistingItemSprite.sprite = spritesBoots[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
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
    }

    public void ShowNewFirstItemText(Item newItem)
    {
        // Item Sprites
        // Set rarity sprite based on item rarity
        switch (newItem.itemRarity)
        {
            case ItemRarity.Common:
                imageNewFirstItemRarity.sprite = spriteCommon;
                break;
            case ItemRarity.Uncommon:
                imageNewFirstItemRarity.sprite = spriteUncommon;
                break;
            case ItemRarity.Rare:
                imageNewFirstItemRarity.sprite = spriteRare;
                break;
            case ItemRarity.Epic:
                imageNewFirstItemRarity.sprite = spriteEpic;
                break;
            case ItemRarity.Legendary:
                imageNewFirstItemRarity.sprite = spriteLegendary;
                break;
        }
        switch (newItem.itemType)
        {
            case ItemType.Wand:
                imageNewFirstItemSprite.sprite = spritesWand[newItem.itemIntSprite]; ;
                break;
            case ItemType.Headwear:
                imageNewFirstItemSprite.sprite = spritesHeadwear[newItem.itemIntSprite];
                break;
            case ItemType.Outfit:
                imageNewFirstItemSprite.sprite = spritesOutfit[newItem.itemIntSprite];
                break;
            case ItemType.Orb:
                imageNewFirstItemSprite.sprite = spritesOrb[newItem.itemIntSprite];
                break;
            case ItemType.Handwear:
                imageNewFirstItemSprite.sprite = spritesHandwear[newItem.itemIntSprite];
                break;
            case ItemType.Ring:
                imageNewFirstItemSprite.sprite = spritesRing[newItem.itemIntSprite];
                break;
            case ItemType.Necklace:
                imageNewFirstItemSprite.sprite = spritesNecklace[newItem.itemIntSprite];
                break;
            case ItemType.Boots:
                imageNewFirstItemSprite.sprite = spritesBoots[newItem.itemIntSprite];
                break;
        }
        // Item UI
        textNewFirstItemLvl.text = "Lv. " + newItem.itemLevel.ToString();
        textNewFirstItemRarity.text = "[" + newItem.itemRarity.ToString().ToUpper() + "]";
        textNewFirstItemType.text = newItem.itemType.ToString();
        // Stats
        textNewFirstItemHealth.text = newItem.healthBonus.ToString();
        textNewFirstItemDamage.text = newItem.damageBonus.ToString();
        textNewFirstItemSpeed.text = newItem.speedBonus.ToString();
        textNewFirstItemResistance.text = newItem.resistanceBonus.ToString();
        // For rare and epic items, generate additional attributes
        if (newItem.itemRarity == ItemRarity.Rare || newItem.itemRarity == ItemRarity.Epic)
        {
            textNewFirstItemExtraBuffName1.enabled = true;
            textNewFirstItemExtraBuffStat1.enabled = true;
            if (newItem.freezeChanceBonus.ToString() != null)
            {
                textNewFirstItemExtraBuffName1.text = "FRZ";
                textNewFirstItemExtraBuffStat1.text = newItem.freezeChanceBonus.ToString();
            }
            if (newItem.fireChanceBonus.ToString() != null)
            {
                textNewFirstItemExtraBuffName1.text = "FIRE";
                textNewFirstItemExtraBuffStat1.text = newItem.fireChanceBonus.ToString();
            }
            if (newItem.comboChanceBonus.ToString() != null)
            {
                textNewFirstItemExtraBuffName1.text = "CMB";
                textNewFirstItemExtraBuffStat1.text = newItem.comboChanceBonus.ToString();
            }
            if (newItem.counterChanceBonus.ToString() != null)
            {
                textNewFirstItemExtraBuffName1.text = "CTR";
                textNewFirstItemExtraBuffStat1.text = newItem.counterChanceBonus.ToString();
            }
        }
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
        textPlayerEquippedItemNecklaceLevel.text = "Lv. " + main.equipmentSlots[6].itemLevel.ToString();
        textPlayerEquippedItemBootsLevel.text = "Lv. " + main.equipmentSlots[7].itemLevel.ToString();

    }
    public void UpdatePlayerItemSprites(int existingItemSlotIndex)
    {
        Image[] spritePlayerEquippedItemRarity = { imagePlayerEquippedItemWandRarity, imagePlayerEquippedItemHeadwearRarity, imagePlayerEquippedItemOutfitRarity, imagePlayerEquippedItemScrollRarity, imagePlayerEquippedItemHandwearRarity, imagePlayerEquippedItemRingRarity, imagePlayerEquippedItemNecklaceRarity, imagePlayerEquippedItemBootsRarity };
        Image[] spritePlayerEquippedItemSprite = { imagePlayerEquippedItemWandSprite, imagePlayerEquippedItemHeadwearSprite, imagePlayerEquippedItemOutfitSprite, imagePlayerEquippedItemScrollSprite, imagePlayerEquippedItemHandwearSprite, imagePlayerEquippedItemRingSprite, imagePlayerEquippedItemNecklaceSprite, imagePlayerEquippedItemBootsSprite };
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

            switch (main.equipmentSlots[existingItemSlotIndex].itemType)
            {
                case ItemType.Wand:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesWand[main.equipmentSlots[existingItemSlotIndex].itemIntSprite]; ;
                    break;
                case ItemType.Headwear:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesHeadwear[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Outfit:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesOutfit[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Orb:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesOrb[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Handwear:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesHandwear[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Ring:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesRing[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Necklace:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesNecklace[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
                case ItemType.Boots:
                    spritePlayerEquippedItemSprite[existingItemSlotIndex].sprite = spritesBoots[main.equipmentSlots[existingItemSlotIndex].itemIntSprite];
                    break;
            }
        }
        
        

    }
    private void SetQuest(int number)
    {
        QuestsSO quest = QuestDatabase.instance.GetQuest(number);
        questsSO = quest;
    }

    public void UpdateQuestUI()
    {
        SetQuest(main.currentQuest);
        Debug.Log(main.currentQuest + " UpdateQuestUI");
        // Quest UI
        Debug.Log("Updated Quest UI " + questsSO.title);
        textQuestTitle.text = questsSO.title;
        if (main.currentQuestAmount >= questsSO.requiredAmount)
        {
            textQuestObjective.text = "<color=green>" + main.currentQuestAmount + "<color=white> / " + questsSO.requiredAmount;
        }
        else
        {
            textQuestObjective.text = "<color=red>" + main.currentQuestAmount + "<color=white> / " + questsSO.requiredAmount;
        }

        textQuestHourglassReward.text = questsSO.hourglass.ToString();
        //imageQuest.sprite = main.questSprite;
    }


    public void OpenSettings()
    {
        panelSettings.SetActive(true);
        panelSettingsTapToClose.SetActive(true);
    }

    public void CloseSettings()
    {
        panelSettings.SetActive(false);
        panelSettingsTapToClose.SetActive(false);
    }
}
