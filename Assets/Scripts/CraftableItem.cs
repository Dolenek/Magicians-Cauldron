using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;
    public Sprite itemSprite;
    public int itemID;
    public int itemLvl;
    public ItemRarity itemRarity;
    public int healthBonus;
    public int defenseBonus;
    public int speedBonus;
    public int damageBonus;
    public float freezeChance;
    public float burnChance;
    public Sprite[] itemSprites;

}

public enum ItemType
{
    Wand,
    Headwear,
    Outfit,
    CloaksAndRobes,
    Handwear,
    Ring,
    Neckles,
    Boots
}

public enum ItemRarity
{
    Common = 4,
    Uncommon = 6,
    Rare = 8,
    Epic = 10,

}