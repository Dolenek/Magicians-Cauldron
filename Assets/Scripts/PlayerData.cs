using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerData :MonoBehaviour
{
    private Main main;
    // Player stats
    public int playerLevel;
    public int health;
    public int resistance;
    public int damage;
    public int speed;
    public float comboChance;
    public float counterChacne;
    public float freezeChance;
    public float fireChance; // Percentage chance (0-100) for bleed

    private void Awake()
    {
        
    }

    private void UpdatePlayerDataStats()
    {
        health = main.health;
        resistance = main.resistance;
        damage = main.damage;
        speed = main.speed;
        comboChance = main.comboChance;
        counterChacne = main.counterChance;
        freezeChance = main.freezeChance;
        fireChance = main.fireChance;
    }
}
