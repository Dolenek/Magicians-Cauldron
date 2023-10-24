using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    private CharacterStats playerStats;
    private EnemyStatsSO enemyStats;
    private Main main;
    private DungeonsManager dungeonsManager;

    private bool playerTurn = true;
    private bool battleOngoing = false;
    public int stage = 1;

    [SerializeField] public GameObject panelWin;
    [SerializeField] public GameObject panelLose;

    private void Awake()
    {
        // Load stats
        playerStats = new CharacterStats();
        main = GetComponent<Main>();


        // Declares GameObjects 
        dungeonsManager = GetComponent<DungeonsManager>();
        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
        
    }

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;



        if (currentSceneName == "Battle")
        {
            // Player stats
            playerStats.damage = main.damage;
            playerStats.health = main.health - 50;
            playerStats.speed = main.speed;
            playerStats.resistance = main.resistance;
            Debug.Log("Player dmg " + playerStats.damage);
            Debug.Log("Enemy dmg " + enemyStats.damage);
            if (playerStats.speed < enemyStats.speed)
            {
                playerTurn = false;
            }
            BattleStarted();
        }
    }

    private void BattleStarted()
    {
        
        int turn = 1;
        battleOngoing = true;
        while (battleOngoing == true && turn < 50)
        {
            
            if (playerTurn) // Player turn
            {
                Debug.Log("Player turn");
                enemyStats.health = enemyStats.health - (playerStats.damage - enemyStats.resistance);

            }
            else //Enemy turn
            {
                Debug.Log("Enemy turn");
                playerStats.health = playerStats.health - (enemyStats.damage - playerStats.resistance);

            }

            // Check if the battle is over
            if (playerStats.health <= 0) // Lose
            {
                BattleLost();
                panelLose.SetActive(true);

            }
            else if (enemyStats.health <= 0) // Win
            {
                BattleWon();
                panelWin.SetActive(true);

            }

            // Switch turns
            playerTurn = !playerTurn;
        }
    }

    private void BattleLost()
    {
        Debug.Log("Battle Lost");
        battleOngoing = false;
    }
    private void BattleWon()
    {
        Debug.Log("Battle Won");
        battleOngoing = false;
        if (stage == 30)
        {
            stage = 1;
        }
        else
        {
            stage++;
        }
        

    }
}
