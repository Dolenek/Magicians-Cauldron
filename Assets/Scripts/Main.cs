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


public class Main : MonoBehaviour
{
    // Player stats
    public int playerLevel;
    public int health;
    public int resistance;
    public int damage;
    public int speed;
    public float comboChance;
    public float counterChance;
    public float freezeChance;
    public float fireChance;

    public int gold;
    public int gems;
    public int hourglass;

    // Inventory
    public Item[] equipmentSlots = new Item[8];

    //FX
    [SerializeField] private GameObject clickFX;
    [SerializeField] private RectTransform buttonPosition;

    private ItemGenerator itemGenerator;
    private UIManager uiManager;
    private EXPBarManager expBarManager;


    private void Awake()
    {
        // Try to find the ItemGenerator component on the Player GameObject
        itemGenerator = GetComponent<ItemGenerator>();
        uiManager = GetComponent<UIManager>();
        expBarManager = GetComponent<EXPBarManager>();
        // If it's still null, create and attach the component
        if (itemGenerator == null)
        {
            itemGenerator = gameObject.AddComponent<ItemGenerator>();
        }
        
    }


    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        DeleteSaveData();
        if (currentSceneName == "MainScene")
        {
            LoadPlayerData();
            UpdateStats();
            uiManager.UpdateAllMainUI();
            uiManager.panelEquipOrSell.SetActive(false);
        }
        
    }
    

    public async void GenerateAndEquipRandomItem()
    {
        // Generate a random item based on player level
        if (hourglass > 0)
        {
            hourglass--;
            // Animation
            Vector3 buttonNewPosition = buttonPosition.position;
            buttonNewPosition.z = 0; buttonNewPosition.y += 0;
            Vector3 coneDirection = Quaternion.Euler(0, 0, 90) * Vector3.right;
            Instantiate(clickFX, buttonNewPosition, Quaternion.LookRotation(coneDirection));
            await Task.Delay(2000);
            Item newItem = itemGenerator.GenerateRandomItem(playerLevel);

            // Check if the player already has an item of the same ItemType
            ItemType newItemType = newItem.itemType;
            int existingItemSlotIndex = GetItemSlotIndexByType(newItemType);

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

    // Get the slot index of an item with the specified ItemType
    private int GetItemSlotIndexByType(ItemType itemType)
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

    // Show a UI prompt to let the player choose whether to replace or sell the new item
    private void ShowEquipOrSellPrompt(Item newItem, int existingItemSlotIndex)
    {

        // Show the UI panel with the stats and options
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

    // Handler for the "Replace" button
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
    }

    // Handler for the "Sell" button
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
    }

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

    // Update player stats based on equipped items
    public void UpdateStats()
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
        if (expBarManager != null)
        {
            saveData.playerCurrentExp = expBarManager.currentXP;
        }
        saveData.health = health;
        saveData.resistance = resistance;
        saveData.damage = damage;
        saveData.speed = speed;
        saveData.comboChance = comboChance;
        saveData.counterChance = counterChance;
        saveData.freezeChance = freezeChance;
        saveData.fireChance = fireChance;
        saveData.hourglass = hourglass;
        // Save player inventory
        saveData.equipmentSlots = new ItemData[equipmentSlots.Length];
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i] != null)
            {
                saveData.equipmentSlots[i] = new ItemData(equipmentSlots[i]);
            }
        }

        // Save the data to a file
        string savePath = Application.persistentDataPath + "/saveData.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, saveData);
        file.Close();
    }

    // Load player inventory and stats
    public void LoadPlayerData()
    {
        Debug.Log("Loading player data");

        // Load the data from the file
        string savePath = Application.persistentDataPath + "/saveData.dat";
        if (File.Exists(savePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(savePath, FileMode.Open);
            SaveData saveData = (SaveData)bf.Deserialize(file);
            file.Close();

            // Load player stats
            playerLevel = saveData.playerLevel;
            if (expBarManager != null)
            {
                expBarManager.currentXP = saveData.playerCurrentExp;
            }
            health = saveData.health;
            resistance = saveData.resistance;
            damage = saveData.damage;
            speed = saveData.speed;
            comboChance = saveData.comboChance;
            counterChance = saveData.counterChance;
            freezeChance = saveData.freezeChance;
            fireChance = saveData.fireChance;
            hourglass = saveData.hourglass;

            // Load player inventory
            for (int i = 0; i < equipmentSlots.Length; i++)
            {
                if (saveData.equipmentSlots[i] != null)
                {
                    equipmentSlots[i] = saveData.equipmentSlots[i].ToItem();
                }
            }

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
    public void DeleteSaveData()
    {
        string savePath = Application.persistentDataPath + "/saveData.dat";
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
    }
}

