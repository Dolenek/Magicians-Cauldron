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
        newItem.damageBonus = Random.Range(playerLevel * 5, playerLevel * 10);
        newItem.healthBonus = Random.Range(playerLevel * 10, playerLevel * 20);
        newItem.resistanceBonus = Random.Range(playerLevel * 2, playerLevel * 5);
        newItem.speedBonus = Random.Range(playerLevel * 2, playerLevel * 5);

        // For rare and epic items, generate additional attributes
        if (newItem.itemRarity >= ItemRarity.Rare)
        {
            newItem.freezeChanceBonus = Random.Range(1.0f, 10.0f);
            newItem.fireChanceBonus = Random.Range(1.0f, 10.0f);
        }

        return newItem;
    }
}
