using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Player stats
    public int playerLevel = 1;
    public int health = 100;
    public int resistance = 10;
    public int damage = 20;
    public int speed = 10;
    public float comboChance = 0f;
    public float counterChance = 0f;
    public float freezeChance = 0f; 
    public float fireChance = 0f; // Percentage chance (0-100) for bleed


    // Equipment UI


    // Equipment types
    private Dictionary<ItemType, Item> equipmentBonuses = new Dictionary<ItemType, Item>();

    // Inventory
    public Item[] equipmentSlots = new Item[8];

    // Equipped item index (corresponding to equipmentSlots)
    private int equippedItemIndex = -1;

    private ItemGenerator itemGenerator;
    private UIManager uiManager;
    private EXPBarManager expBarManager;
    // Initialize itemGenerator in Start or Awake
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
        uiManager.UpdatePlayerTextStats();
    }

    // In your Player script, call this when you want to generate and equip an item
    public void GenerateAndEquipRandomItem()
    {
        // Generate a random item based on player level
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
            // Player doesn't have an item of the same type, simply equip the new item
            EquipItem(newItem.itemType);
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
        // Equip the new item in place of the existing item
        equipmentSlots[existingItemSlotIndex] = newItem;

        // Update player stats
        UpdateStats();
        // Update player item sprites in players inventory
        uiManager.UpdatePlayerItemSprites(existingItemSlotIndex);
        // Close the UI panel
        uiManager.panelEquipOrSell.SetActive(false);
    }

    // Handler for the "Sell" button
    private void SellNewItemAtExisting(Item newItem)
    {
        // Gain Gold based on the rarity and lvl of the players cauldron

        // Gain EXP based on the rarity of the item
        expBarManager.GainXP(((int)newItem.itemRarity));
        // Close the UI panel
        uiManager.panelEquipOrSell.SetActive(false);
        newItem.itemRarity = 0; //Insures that the itemRarity isnt adding up
    }

    // Update player stats based on equipped items
    private void UpdateStats()
    {
        // Store the base stats
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

        // Update stat Text
        uiManager.UpdatePlayerTextStats();
    }

    // Equip an item to a specific slot based on the
    public void EquipItem(ItemType itemType)
    {
        if (equipmentBonuses.ContainsKey(itemType))
        {
            Item item = equipmentBonuses[itemType];

            // Unequip the current item in the same slot (if any)
            UnequipItem(itemType);

            // Equip the new item
            int slotIndex = (int)itemType;
            equipmentSlots[slotIndex] = item;
            equippedItemIndex = slotIndex;

            // Update player stats based on the equipped item
            UpdateStats();
        }
    }

    // Unequip an item based on the generated ItemType
    public void UnequipItem(ItemType itemType)
    {
        if (equipmentBonuses.ContainsKey(itemType))
        {
            int slotIndex = (int)itemType;

            // Check if an item is currently equipped in the specified slot
            if (equipmentSlots[slotIndex] != null)
            {
                // Unequip the item from the specified slot
                equipmentSlots[slotIndex] = null;

                // Update player stats
                UpdateStats();
            }
        }
    }
    // Sell the equipped item ????????
    public void SellItem()
    {
        if (equippedItemIndex >= 0 && equippedItemIndex < equipmentSlots.Length)
        {
            equipmentSlots[equippedItemIndex] = null;
            equippedItemIndex = -1;

            // Update player stats
            UpdateStats();
        }
    }
}
