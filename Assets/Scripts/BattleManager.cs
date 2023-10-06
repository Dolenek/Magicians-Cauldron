using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public CharacterStats playerStats;
    public EnemyStatsSO enemyStats;
    private Main main;

    private bool playerTurn = true;

    private void Awake()
    {
        main = GetComponent<Main>();
        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
    }

    private void Start()
    {
        if (playerStats.speed <= enemyStats.speed)
        {
            playerTurn = false;
        }
        // Player stats
        playerStats.damage = main.damage;
        playerStats.health = main.health;
        playerStats.speed = main.speed;
        playerStats.resistance = main.resistance;


    }

    private void Update()
    {
        if (playerTurn)
        {
            // Player's turn
            // Implement player's attack logic here
            // Deduct enemy's health based on player's damage, considering enemy's resistance
        }
        else
        {
            // Enemy's turn
            // Implement enemy's attack logic here
            // Deduct player's health based on enemy's damage, considering player's resistance
            playerTurn =true;
        }

        // Check if the battle is over
        if (playerStats.health <= 0)
        {
            // Player loses
            // Implement game over logic
        }
        else if (enemyStats.health <= 0)
        {
            // Enemy loses
            // Implement victory logic
        }

        // Switch turns
        playerTurn = !playerTurn;
    }
}
