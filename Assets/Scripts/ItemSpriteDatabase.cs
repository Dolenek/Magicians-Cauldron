using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteDatabase : MonoBehaviour
{
    public static ItemSpriteDatabase instance;

    public Dictionary<ItemType, Sprite[]> itemSprites = new Dictionary<ItemType, Sprite[]>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeItemSprites();
    }

    private void InitializeItemSprites()
    {
        itemSprites[ItemType.Wand] = new Sprite[] { };
        itemSprites[ItemType.Headwear] = new Sprite[] { };
        itemSprites[ItemType.Outfit] = new Sprite[] { };
        itemSprites[ItemType.Handwear] = new Sprite[] { };
        itemSprites[ItemType.CloaksAndRobes] = new Sprite[] { };
        itemSprites[ItemType.Boots] = new Sprite[] { };
        itemSprites[ItemType.Ring] = new Sprite[] { };
        itemSprites[ItemType.Neckles] = new Sprite[] { };
    }
}
