using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Class for saving and loading player data
[System.Serializable]
public class SaveData
{
    public int playerLevel;
    public int playerExp;
    public int health;
    public int resistance;
    public int damage;
    public int speed;
    public float comboChance;
    public float counterChance;
    public float freezeChance;
    public float fireChance;
    public ItemData[] equipmentSlots;
}

// Class for serializing Item data
[System.Serializable]
public class ItemData
{
    public ItemType itemType;
    public ItemRarity itemRarity;
    public int itemLevel;
    public int healthBonus;
    public int resistanceBonus;
    public int damageBonus;
    public int speedBonus;
    public float comboChanceBonus;
    public float counterChanceBonus;
    public float freezeChanceBonus;
    public float fireChanceBonus;

    public ItemData(Item item)
    {

        itemType = item.itemType;
        itemRarity = item.itemRarity;
        itemLevel = item.itemLevel;
        healthBonus = item.healthBonus;
        resistanceBonus = item.resistanceBonus;
        damageBonus = item.damageBonus;
        speedBonus = item.speedBonus;
        comboChanceBonus = item.comboChanceBonus;
        counterChanceBonus = item.counterChanceBonus;
        freezeChanceBonus = item.freezeChanceBonus;
        fireChanceBonus = item.fireChanceBonus;
    }

    public Item ToItem()
    {
        Item item = new Item();

        item.itemType = itemType;
        item.itemRarity = itemRarity;
        item.itemLevel = itemLevel;
        item.healthBonus = healthBonus;
        item.resistanceBonus = resistanceBonus;
        item.damageBonus = damageBonus;
        item.speedBonus = speedBonus;
        item.comboChanceBonus = comboChanceBonus;
        item.counterChanceBonus = counterChanceBonus;
        item.freezeChanceBonus = freezeChanceBonus;
        item.fireChanceBonus = fireChanceBonus;
        return item;
    }
}
