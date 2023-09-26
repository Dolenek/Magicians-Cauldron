using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private Button cauldron;
    [SerializeField] private Image itemImagine;
    
    public void OnCauldronClick()
    {
        Item newItem = GenerateRandomItem();
        DisplayItem(newItem);
    }

    private Item GenerateRandomItem()
    {
        ItemType randomItemType = (ItemType)Random.Range(0, System.Enum.GetValues(typeof(ItemType)).Length);
        ItemRarity randomRarity = (ItemRarity)Random.Range(0, System.Enum.GetValues(typeof(ItemRarity)).Length);

        EXPBarController exp = EXPBarController.instance;

        Item newItem = new Item
        {
            itemType = randomItemType,
            itemRarity = randomRarity,
            itemLvl = Random.Range(Mathf.Max(1, exp.currentLevel - 2), exp.currentLevel + 3), // Mathf.Max zaruèí, že pokud bude vygenerované èíslo menší než 1, tak ho nastaví na 1
            healthBonus = Random.Range(0, 11), 
            defenseBonus = Random.Range(0, 11), 
            speedBonus = Random.Range(0, 11),  
            damageBonus = Random.Range(0, 11),
            itemSprites = ItemSpriteDatabase.instance.itemSprites[randomItemType]

        };
        exp.GainExp(((int)randomRarity) * 2 + 3);
        Debug.Log(((int)randomRarity) * 2 + 3);
        int randomSpriteIndex = Random.Range(0, newItem.itemSprites.Length);
        newItem.itemSprite = newItem.itemSprites[randomSpriteIndex];

        return newItem;
    }

    private void CraftItem()
    {
        
    }

    private void DisplayItem(Item item)
    {
        GameObject itemPrefab = item.itemPrefab;
        if (itemPrefab != null)
        {
            Instantiate(itemPrefab, itemImagine.transform.position, Quaternion.identity);
        }
    }
}
