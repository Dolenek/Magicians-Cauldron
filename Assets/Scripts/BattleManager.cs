using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    private CharacterStats playerStats;
    private EnemyStatsSO enemyStats;
    private Main main;

    private bool playerTurn = true;
    private bool battleOngoing = false;

    public int stage;

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
        stage = PlayerPrefs.GetInt("CurrentStage", 1);
        if (currentSceneName == "Battle")
        {

            SetEnemies(1, stage);
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

            // Enemy stats
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
        while (battleOngoing == true && turn <= 20)
        {
            Debug.Log(turn);
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
        battleOngoing = false;
        if (stage == 30)
        {
            stage = 1;
        }
        else
        {
            stage++;
        }
        PlayerPrefs.SetInt("CurrentStage", stage);
        PlayerPrefs.Save();

    }
    public void SetEnemies(int island, int stage)
    {
        EnemyStatsSO enemy = EnemyDatabase.instance.GetEnemy(island, stage);
        enemyStats = enemy;
    }
}
