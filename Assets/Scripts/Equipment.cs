using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
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
    Common,
    Uncommon,
    Rare,
    Epic
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
