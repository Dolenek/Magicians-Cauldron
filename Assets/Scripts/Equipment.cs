using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Sprite itemSprite;
    public int itemIntSprite;
}

public enum ItemRarity
{
    Common = 4,
    Uncommon = 6,
    Rare = 8,
    Epic = 10,
    Legendary = 12,
    Mythic = 14,
    Ancient = 16,
    Godly = 20  
    
}

public enum ItemType
{
    Wand,
    Headwear,
    Outfit,
    Orb,
    Handwear,
    Ring,
    Necklace,
    Boots
}

/*public class EquippedItem
{
    private TMP_Text textLevel;
    private TMP_Text textRarity;
}

public class ItemTypes : EquippedItem
{
    public ItemType Wand;
}*/
