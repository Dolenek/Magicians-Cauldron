using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int playerLevel = 1;
    public int health = 100;
    public int resistance = 10;
    public int damage = 20;
    public int speed = 10;
    public float comboChance = 0f;
    public float counterChance = 0f;
    public float freezeChance = 0f;
    public float fireChance = 0f;
    public Sprite playerSprite;

    public PlayerData(int damage, int health, int speed, int resistance, Sprite playerSprite)
    {
        this.damage = damage;
        this.health = health;
        this.speed = speed;
        this.resistance = resistance;
        this.playerSprite = playerSprite;
        
    }
}
