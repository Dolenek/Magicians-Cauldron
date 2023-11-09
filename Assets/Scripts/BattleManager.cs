using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    private CharacterStats playerStats;
    private EnemyStatsSO enemyStatsSO;
    private Main main;

    private bool playerTurn = true;
    private bool battleOngoing = false;

    private bool playerFrozen = false;
    private bool enemyFrozen = false;
    private bool playeOnFire = false;
    private bool enemyOnFire = false;


    [SerializeField] public GameObject panelWin;
    [SerializeField] public GameObject panelLose;


    private void Awake()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;
        // Load stats
        playerStats = new CharacterStats();
        main = GetComponent<Main>();


        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
        main.currentStage = PlayerPrefs.GetInt("CurrentStage", 1);
        if (currentSceneName == "Battle")
        {

            SetEnemies(1, main.currentStage);
        }
    }

    private void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;



        if (currentSceneName == "Battle")
        {
            main.LoadPlayerData();

            // Player stats
            playerStats.damage = main.damage;
            playerStats.health = main.health;
            playerStats.speed = main.speed;
            playerStats.resistance = main.resistance;
            playerStats.counterChance = main.counterChance;
            playerStats.comboChance = main.comboChance;
            playerStats.fireChance = main.fireChance;
            playerStats.freezeChance = main.freezeChance;
            Debug.Log("Player dmg " + playerStats.damage);

            // Enemy stats
            Debug.Log("Enemy dmg " + enemyStatsSO.damage);
            if (playerStats.speed < enemyStatsSO.speed)
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
        while (battleOngoing == true && turn <= 20)
        {
            Debug.Log(turn);
            if (playerTurn) // Player turn
            {
                Debug.Log("Player turn");

                enemyStatsSO.health = enemyStatsSO.health - (playerStats.damage - enemyStatsSO.resistance);


            }
            else //Enemy turn
            {
                Debug.Log("Enemy turn");
                playerStats.health = playerStats.health - (enemyStatsSO.damage - playerStats.resistance);

            }

            // Check if the battle is over
            if (playerStats.health <= 0) // Lose
            {
                BattleLost();
                panelLose.SetActive(true);

            }
            else if (enemyStatsSO.health <= 0) // Win
            {
                BattleWon();
                panelWin.SetActive(true);

            }

            // Switch turns
            playerTurn = !playerTurn;
            turn++;
        }
        if (turn > 20)
        {
            Debug.Log("Battle timed out");
            BattleLost();
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

        main.hourglass = main.hourglass + enemyStatsSO.hourglass;
        main.SavePlayerData();
        battleOngoing = false;
        if (main.currentStage == 30)
        {
            main.currentStage = 1;
        }
        else
        {
            main.currentStage++;
        }
        PlayerPrefs.SetInt("CurrentStage", main.currentStage);
        PlayerPrefs.Save();

    }
    public void SetEnemies(int island, int stage)
    {
        EnemyStatsSO enemy = EnemyDatabase.instance.GetEnemy(island, stage);
        enemyStatsSO = enemy;
    }
}
