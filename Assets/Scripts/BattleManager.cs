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
    private QuestsSO questsSO;
    private QuestDatabase questDatabase;

    private bool playerTurn = true;
    private bool battleOngoing = false;

    private bool playerFrozen = false;
    private bool enemyFrozen = false;
    private int playerOnFire = 0;
    private int enemyOnFire = 0;

    [SerializeField] public GameObject panelWin;
    [SerializeField] public GameObject panelLose;


    private void Awake()
    {

        string currentSceneName = SceneManager.GetActiveScene().name;
        // Load stats
        playerStats = new CharacterStats();
        main = GetComponent<Main>();
        questDatabase = GetComponent<QuestDatabase>();

        
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
            main.LoadPlayerData();
            Debug.Log(main.currentStage + "BattleManager main.currentStage");
            enemyStats = SetEnemyStats(1, main.currentStage);

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
            Debug.Log("Enemy dmg " + enemyStats.damage);
            if (playerStats.speed < enemyStats.speed)
            {
                playerTurn = false;
            }

            // Check for quests
            questsSO = questDatabase.GetQuest(main.currentStage);

            BattleStarted();
        }
    }

    private void BattleStarted()
    {
        Debug.Log("Battle Started");
        System.Random random = new System.Random();

        int turn = 1;

        battleOngoing = true;
        while (battleOngoing == true && turn <= 20)
        {
            Debug.Log(turn + " turn");
            if (playerTurn) // Player turn
            {
                Debug.Log("Player turn");
                if (playerOnFire > 0) // Player is on fire
                {
                    playerStats.health = playerStats.health - enemyStats.damage / 10;
                    playerOnFire--;
                }

                int randomNumberFire = random.Next(1, 101);
                int randomNumberFreeze = random.Next(1, 101);
                int randomNumberCounter = random.Next(1, 101);
                int randomNumberCombo = random.Next(1, 101);


                if (playerFrozen == true) // Player is frozen
                {
                    playerFrozen = false;
                }
                else
                {
                    do
                    {
                        randomNumberCombo = random.Next(1, 101);
                        randomNumberCounter = random.Next(1, 101);
                        if (randomNumberFire <= playerStats.fireChance && enemyOnFire < 3) // Player sets Enemy on fire
                        {
                            enemyOnFire = 3;
                        }

                        if (randomNumberFreeze <= playerStats.freezeChance && enemyFrozen == false) // Player freezes Enemy
                        {
                            enemyFrozen = true;
                        }

                        //Attack enemy
                        enemyStats.health -= (playerStats.damage - enemyStats.resistance);
                        //Check if enemy Counters
                        if (randomNumberCounter <= enemyStats.counterChance)
                        {
                            playerStats.health -= (enemyStats.damage - playerStats.resistance);
                        }

                    } while (randomNumberCombo <= playerStats.comboChance && enemyStats.health > 0);
                }


            }
            else //Enemy turn
            {
                Debug.Log("Enemy turn");
                if (enemyOnFire > 0) // Enemy is on fire
                {
                    enemyStats.health -= playerStats.damage / 10;
                    enemyOnFire--;
                }

                int randomNumberFire = random.Next(1, 101);
                int randomNumberFreeze = random.Next(1, 101);
                int randomNumberCounter = random.Next(1, 101);
                int randomNumberCombo = random.Next(1, 101);


                if (enemyFrozen == true) // Enemy is frozen
                {
                    enemyFrozen = false;
                }
                else
                {
                    do
                    {
                        randomNumberCombo = random.Next(1, 101);
                        randomNumberCounter = random.Next(1, 101);
                        if (randomNumberFire <= enemyStats.fireChance && playerOnFire < 3) // Enemy sets player on fire
                        {
                            playerOnFire = 3;
                        }

                        if (randomNumberFreeze <= enemyStats.freezeChance && playerFrozen == false) // Enemy freezes Player
                        {
                            playerFrozen = true;
                        }

                        //Attack player
                        playerStats.health -= (enemyStats.damage - playerStats.resistance);
                        //Check if player Counters
                        if (randomNumberCounter <= playerStats.counterChance)
                        {
                            enemyStats.health -= (playerStats.damage - enemyStats.resistance);
                        }

                    } while (randomNumberCombo <= enemyStats.comboChance && playerStats.health > 0);
                }

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
        main.hourglass += enemyStats.hourglass;
        battleOngoing = false;
        if (main.currentStage == 30)
        {
            main.currentStage = 1;
        }
        else
        {
            main.currentStage++;
        }
    }
    public EnemyStatsSO SetEnemyStats(int island, int stage)
    {
        EnemyStatsSO enemy = EnemyDatabase.instance.GetEnemy(island, stage);
        return enemy;
    }
}
