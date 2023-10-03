using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // Singleton pattern for ItemGenerator
    public static ItemGenerator Instance { get; private set; }



    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Ensure there is only one instance of ItemGenerator
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Item GenerateRandomItem(int playerLevel)
    {
        Item newItem = new Item();

        // Randomly generate item type
        newItem.itemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);
        newItem.itemLevel = Random.Range(Mathf.Max(1, playerLevel - 1),playerLevel+2);
        Debug.Log(newItem.itemLevel);

        // Randomly generate item rarity
        float rarityRoll = Random.value;
        if (rarityRoll < 0.6f) // 60% chance for Common
            newItem.itemRarity = ItemRarity.Common;
        else if (rarityRoll < 0.85f) // 25% chance for Uncommon
            newItem.itemRarity = ItemRarity.Uncommon;
        else if (rarityRoll < 0.95f) // 10% chance for Rare
            newItem.itemRarity = ItemRarity.Rare;
        else // 5% chance for Epic
            newItem.itemRarity = ItemRarity.Epic;

        // Randomly generate item stats based on player level and rarity
        // Adjust these formulas as needed
        newItem.damageBonus = Random.Range(newItem.itemLevel * 5, newItem.itemLevel * 10);
        newItem.healthBonus = Random.Range(newItem.itemLevel * 10, newItem.itemLevel * 20);
        newItem.resistanceBonus = Random.Range(newItem.itemLevel * 2, newItem.itemLevel * 5);
        newItem.speedBonus = Random.Range(newItem.itemLevel * 2, newItem.itemLevel * 5);

        // For rare and epic items, generate additional attributes
        if (newItem.itemRarity >= ItemRarity.Rare)
        {
            newItem.freezeChanceBonus = Random.Range(1.0f, 10.0f);
            newItem.fireChanceBonus = Random.Range(1.0f, 10.0f);
        }

        return newItem;
    }
}
