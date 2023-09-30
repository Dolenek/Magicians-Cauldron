using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item 
{
    public int healthBonus;
    public int defenseBonus;
    public int damageBonus;
    public int speedBonus;
    public ItemType itemType;
    public ItemRarity itemRarity;
    public float stunChanceBonus;
    public float bleedChanceBonus;
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
