using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    // Singleton pattern for ItemGenerator
    // Static znamená, že mùže existovat pouze jenom 1 instance této tøídy
    public static ItemGenerator Instance { get; private set; }

    private UIManager uiManager;

    private void Awake()
    {
        // Ensure there is only one instance of ItemGenerator
        uiManager = GetComponent<UIManager>();
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
            int randomStat = Random.Range(0, 4);
            float randomNum = Random.Range(1.0f, 10.0f);
            float roundedNum = Mathf.Round(randomNum * 10.0f) / 10.0f;
            switch (randomStat)
            {
                case 0:
                    newItem.freezeChanceBonus = roundedNum;
                    break;
                case 1:
                    newItem.fireChanceBonus = roundedNum;
                    break;
                case 2:
                    newItem.comboChanceBonus = roundedNum;
                    break;
                case 3:
                    newItem.counterChanceBonus = roundedNum;
                    break;
            }
        }
        switch(newItem.itemType)
        {
            case ItemType.Wand:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesWand.Length);
                newItem.itemSprite = uiManager.spritesWand[newItem.itemIntSprite];
                break;
            case ItemType.Headwear:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesHeadwear.Length);
                newItem.itemSprite = uiManager.spritesHeadwear[newItem.itemIntSprite];
                break;
            case ItemType.Outfit:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesOutfit.Length);
                newItem.itemSprite = uiManager.spritesOutfit[newItem.itemIntSprite];
                break;
            case ItemType.Orb:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesOrb.Length);
                newItem.itemSprite = uiManager.spritesOrb[newItem.itemIntSprite];
                break;
            case ItemType.Handwear:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesHandwear.Length);
                newItem.itemSprite = uiManager.spritesHandwear[newItem.itemIntSprite];
                break;
            case ItemType.Ring:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesRing.Length);
                newItem.itemSprite = uiManager.spritesRing[newItem.itemIntSprite];
                break;
            case ItemType.Necklace :
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesNecklace.Length);
                newItem.itemSprite = uiManager.spritesNecklace[newItem.itemIntSprite];
                break;
            case ItemType.Boots:
                newItem.itemIntSprite = Random.Range(0, uiManager.spritesBoots.Length);
                newItem.itemSprite = uiManager.spritesBoots[newItem.itemIntSprite];
                break;
        }
        return newItem;
    }
}
