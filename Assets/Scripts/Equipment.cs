using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public int itemLevel;
    public int healthBonus;
    public int resistanceBonus;
    public int damageBonus;
    public int speedBonus;
    public ItemType itemType;
    public ItemRarity itemRarity;
    public float freezeChanceBonus;
    public float fireChanceBonus;
    public float comboChanceBonus;
    public float counterChanceBonus;
}

public enum ItemRarity
{
    Common = 4,
    Uncommon = 6,
    Rare = 8,
    Epic = 10
}

public enum ItemType
{
    Wand,
    Headwear,
    Outfit,
    Cloak,
    Handwear,
    Ring,
    Necklace,
    Boots
}
