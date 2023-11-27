using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



[DefaultExecutionOrder(-100)]
public class Main : MonoBehaviour
{
    // Player stats
    public int health;
    public int resistance;
    public int damage;
    public int speed;
    public float comboChance;
    public float counterChance;
    public float freezeChance;
    public float fireChance;

    // Player level
    public int playerLevel;
    public int playerCurrentEXP;

    // Resources
    public int gold;
    public int gems;
    public int hourglass;

    //Dungeons
    public int currentStage = 1;

    //Quests
    public int currentQuest = 1;
    public int currentQuestAmount = 0;

    //Animation
    private bool delayIsActive = false;

    public string currentSceneName;
    
    // Inventory
    public Item[] equipmentSlots = new Item[8];

    //FX
    [SerializeField] private GameObject clickFX;
    [SerializeField] private RectTransform buttonPosition;

    private ItemGenerator itemGenerator;
    private UIManager uiManager;
    private EXPBarManager expBarManager;
    private QuestDatabase questDatabase;
    private QuestsSO questsSO;

    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        itemGenerator = GetComponent<ItemGenerator>();
        uiManager = GetComponent<UIManager>();
        expBarManager = GetComponent<EXPBarManager>();
        questDatabase = GetComponent<QuestDatabase>();
        if (currentSceneName == "MainScene")
        {
            if (itemGenerator == null)
                itemGenerator = gameObject.AddComponent<ItemGenerator>();
            if (uiManager == null)
                uiManager = gameObject.AddComponent<UIManager>();
        }
    }


    private void Start()
    {
        //DeleteSaveData();
        if (currentSceneName == "MainScene")
        {
            SetQuest(currentQuest);
            LoadPlayerData();
            SetQuest(currentQuest);
            if (currentStage == 0)
            {
                currentStage = 1;
            }
            UpdateQuests();
            UpdateStats();
            uiManager.UpdateAllMainUI();
            uiManager.panelEquipOrSell.SetActive(false);
        }

    }

    public async void GenerateAndEquipRandomItem()
    {
        // Generate a random item based on player level
        if (hourglass > 0 && delayIsActive == false)
        {
            hourglass--;

            // Animation
            Vector3 buttonNewPosition = buttonPosition.position;
            buttonNewPosition.z = 0; buttonNewPosition.y += 0;
            Vector3 coneDirection = Quaternion.Euler(0, 0, 90) * Vector3.right;

            Instantiate(clickFX, buttonNewPosition, Quaternion.LookRotation(coneDirection));
            delayIsActive = true;
            await Task.Delay(2000);
            delayIsActive = false;

            //Item Generation
            Item newItem = itemGenerator.GenerateRandomItem(playerLevel);
            ItemType newItemType = newItem.itemType;
            int existingItemSlotIndex = GetItemSlotIndexByType(newItemType);

            //Quest
            if (questsSO.goalType == GoalType.GenerateItem && !IsReached())
                currentQuestAmount++;

            if (existingItemSlotIndex >= 0)
            {
                // Player already has an item of the same type
                ShowEquipOrSellPrompt(newItem, existingItemSlotIndex);
            }
            else
            {
                Debug.LogError("AAAAAAAAA Main GenerateAndEquipRandomItem");
            }
        }
        else
        {
            Debug.Log("Not enough hourglass");
        }
    }

    private int GetItemSlotIndexByType(ItemType itemType)// Get the slot index of an item with the specified ItemType
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i] != null && equipmentSlots[i].itemType == itemType)
            {
                return i;
            }
        }
        return -1; // Item not found
    }

    private void ShowEquipOrSellPrompt(Item newItem, int existingItemSlotIndex)
    {

        // Show the UI panel with the stats and options
        if (equipmentSlots[existingItemSlotIndex].damageBonus == 0)
        {

            uiManager.panelEquipOrSellFirst.SetActive(true);
            // Show the stats of newly generated item
            uiManager.ShowNewFirstItemText(newItem);

            // Remove any existing listeners first
            uiManager.buttonEquipFirst.onClick.RemoveAllListeners();

            // Add button click events to handle player choice
            uiManager.buttonEquipFirst.onClick.AddListener(() => EquipFirstItem(newItem, existingItemSlotIndex));
        }
        else
        {
            uiManager.panelEquipOrSell.SetActive(true);
            // Show the stats of newly generated item
            uiManager.ShowNewItemText(newItem);
            // Show the stats of the already equipped item
            uiManager.ShowExistingItemText(existingItemSlotIndex);

            // Remove any existing listeners first
            uiManager.buttonEquip.onClick.RemoveAllListeners();
            uiManager.buttonSell.onClick.RemoveAllListeners();

            // Add button click events to handle player choice
            uiManager.buttonEquip.onClick.AddListener(() => ReplaceItemWithNew(newItem, existingItemSlotIndex));
            uiManager.buttonSell.onClick.AddListener(() => SellNewItemAtExisting(newItem));
        }
        
        
    }

    private void EquipFirstItem(Item newItem, int existingItemSlotIndex)
    {

        // Equip the new item in place of the existing item
        equipmentSlots[existingItemSlotIndex] = newItem;

        // Update player stats
        UpdateStats();
        uiManager.UpdateAllMainUI();
        // Update player item sprites in players inventory
        uiManager.UpdatePlayerItemSprites(existingItemSlotIndex);
        // Close the UI panel
        uiManager.panelEquipOrSellFirst.SetActive(false);
        uiManager.textNewFirstItemExtraBuffStat1.enabled = false;
        uiManager.textNewFirstItemExtraBuffName1.enabled = false;

        SavePlayerData();
    }

    private void ReplaceItemWithNew(Item newItem, int existingItemSlotIndex)
    {
        // Sell the existing item before equipping the new one
        SellItem(equipmentSlots[existingItemSlotIndex]);

        // Equip the new item in place of the existing item
        equipmentSlots[existingItemSlotIndex] = newItem;

        // Update player stats
        UpdateStats();
        uiManager.UpdateAllMainUI();
        // Update player item sprites in players inventory
        uiManager.UpdatePlayerItemSprites(existingItemSlotIndex);
        // Close the UI panel
        uiManager.panelEquipOrSell.SetActive(false);
        uiManager.textNewItemExtraBuffStat1.enabled = false;
        uiManager.textNewItemExtraBuffName1.enabled = false;
        uiManager.textExistingItemExtraBuffName1.enabled = false;
        uiManager.textExistingItemExtraBuffStat1.enabled = false;

        SavePlayerData();
    } // Handler for the "Replace" button

    private void SellNewItemAtExisting(Item newItem)
    {
        // Gain Gold based on the rarity and lvl of the players cauldron

        // Gain EXP based on the rarity of the item
        expBarManager.GainXP(((int)newItem.itemRarity));
        // Update player stats
        UpdateStats();
        uiManager.UpdateAllMainUI();
        // Close the UI panel and other UIs
        uiManager.panelEquipOrSell.SetActive(false);
        uiManager.textNewItemExtraBuffStat1.enabled = false;
        uiManager.textNewItemExtraBuffName1.enabled = false;
        uiManager.textExistingItemExtraBuffName1.enabled = false;
        uiManager.textExistingItemExtraBuffStat1.enabled = false;

        newItem.itemRarity = 0; //Insures that the itemRarity isnt adding up

        SavePlayerData();
    }// Handler for the "Sell" button

    private void SellItem(Item item)
    {
        // Gain Gold based on the rarity and lvl of the players cauldron

        // Gain EXP based on the rarity of the item
        expBarManager.GainXP(((int)item.itemRarity));
        // Update player stats
        UpdateStats();
        uiManager.UpdateAllMainUI();
        item.itemRarity = 0; //Insures that the itemRarity isnt adding up
    }

    public void UpdateStats() // Update player stats based on equipped items
    {

        int baseHealth = 100;
        int baseDefense = 10;
        int baseDamage = 20;
        int baseSpeed = 10;
        float baseStunChance = 0f;
        float baseBleedChance = 0f;
        float baseComboChance = 0f;
        float baseCounterChacne = 0f;

        // Apply bonuses from equipped items
        foreach (Item item in equipmentSlots)
        {
            if (item != null)
            {
                baseHealth += item.healthBonus;
                baseDefense += item.resistanceBonus;
                baseDamage += item.damageBonus;
                baseSpeed += item.speedBonus;
                baseStunChance += item.freezeChanceBonus;
                baseBleedChance += item.fireChanceBonus;
                baseComboChance += item.comboChanceBonus;
                baseCounterChacne += item.counterChanceBonus;
            }
        }

        // Update the player's stats
        health = baseHealth;
        resistance = baseDefense;
        damage = baseDamage;
        speed = baseSpeed;
        freezeChance = baseStunChance;
        fireChance = baseBleedChance;
        comboChance = baseComboChance;
        counterChance = baseCounterChacne;
    }
    
    public void SavePlayerData()
    {
        Debug.Log("Saving player data");
        // Create a new instance of the SaveData class
        SaveData saveData = new SaveData();

        // Save player stats
        saveData.playerLevel = playerLevel;

        saveData.playerCurrentExp = playerCurrentEXP;


        saveData.health = health;
        saveData.resistance = resistance;
        saveData.damage = damage;
        saveData.speed = speed;
        saveData.comboChance = comboChance;
        saveData.counterChance = counterChance;
        saveData.freezeChance = freezeChance;
        saveData.fireChance = fireChance;
        saveData.hourglass = hourglass;
        
        saveData.currentQuest = currentQuest;
        saveData.currentQuestAmount = currentQuestAmount;
       
        UpdateQuests();
        
        
        saveData.currentStage = currentStage;
        // Save player inventory
        saveData.equipmentSlots = new ItemData[equipmentSlots.Length];
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].damageBonus != 0)
            {
                saveData.equipmentSlots[i] = new ItemData(equipmentSlots[i]);
            }
        }


        // Save the data to a file
        string savePath = Application.persistentDataPath + "/saveData.kys";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, saveData);
        file.Close();
    }
    
    public void LoadPlayerData()// Load player inventory and stats
    {
        Debug.Log("Loading player data");

        // Load the data from the file
        string savePath = Application.persistentDataPath + "/saveData.kys";
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();

            // Load player stats
            playerLevel = saveData.playerLevel;

            playerCurrentEXP = saveData.playerCurrentExp;

            health = saveData.health;
            resistance = saveData.resistance;
            damage = saveData.damage;
            speed = saveData.speed;
            comboChance = saveData.comboChance;
            counterChance = saveData.counterChance;
            freezeChance = saveData.freezeChance;
            fireChance = saveData.fireChance;
            hourglass = saveData.hourglass;
            currentStage = saveData.currentStage;
            
            // Load player inventory
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (saveData.equipmentSlots[i] != null)
                {
                    equipmentSlots[i] = saveData.equipmentSlots[i].ToItem();
                }
            }
            // Update and Load quests
            currentQuest = saveData.currentQuest;

            currentQuestAmount = saveData.currentQuestAmount;
            Debug.Log(saveData.currentQuestAmount + " Main LoadPlayerData");

            // Update player item sprites in players inventory
            if (uiManager != null)
            {
                for (int i = 0; i < equipmentSlots.Length; i++)
                {
                    if (saveData.equipmentSlots[i] != null)
                    {
                        uiManager.UpdatePlayerItemSprites(i);
                    }
                }
                // Update player level text
                uiManager.UpdatePlayerTextItemLevel();


                // Update player stats and inventory UI
                UpdateStats();
                uiManager.UpdateAllMainUI();
            }


        }
        
    }
    public void CompleteQuest()
    {
        if (IsReached())
        {
            hourglass += questsSO.hourglass;
            currentQuest++;
            currentQuestAmount = 0;
            uiManager.UpdateAllMainUI();
            SavePlayerData();
            SetQuest(currentQuest);
        }
    }
    private void UpdateQuests()
    {
        if (currentSceneName == "MainScene")
        {

            //Quests
            questDatabase.GetQuest(currentQuest);
            if (!IsReached())
            {
                switch (questsSO.goalType)
                {
                    case GoalType.GenerateRareItem:

                    case GoalType.ReachLevel:
                        currentQuestAmount = playerLevel;
                        uiManager.UpdateQuestUI();
                        break;
                    case GoalType.ReachStage:
                        currentQuestAmount = currentStage;
                        uiManager.UpdateQuestUI();
                        break;
                }
                
            }
        }
        
    }
    
    public void DeleteSaveData()
    {
        string savePath = Application.persistentDataPath + "/saveData.kys";
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
        SceneManager.LoadScene("MainScene");
    }
    private void SetQuest(int number)
    {
        QuestsSO quest = QuestDatabase.instance.GetQuest(number);
        questsSO = quest;
    }
    private bool IsReached()
    {
        return (currentQuestAmount >= questsSO.requiredAmount);
    }
}

