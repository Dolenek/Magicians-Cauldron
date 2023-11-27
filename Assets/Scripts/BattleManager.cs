using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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

    [SerializeField] private GameObject battleLog;
    [SerializeField] private GameObject panelTapToClose;
    [SerializeField] private GameObject battleLogEntryPrefab;
    [SerializeField] private Transform battleLogContent;

    [SerializeField] public GameObject panelWin;
    [SerializeField] public GameObject panelLose;

    [SerializeField] private Image imageEnemySprite;
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
            enemyStats = SetEnemyStats(1, main.currentStage);

            // set Players stats
            playerStats.damage = main.damage;
            playerStats.health = main.health;
            playerStats.speed = main.speed;
            playerStats.resistance = main.resistance;
            playerStats.counterChance = main.counterChance;
            playerStats.comboChance = main.comboChance;
            playerStats.fireChance = main.fireChance;
            playerStats.freezeChance = main.freezeChance;

            // Determine who starts first
            if (playerStats.speed < enemyStats.speed)
            {
                playerTurn = false;
            }

            imageEnemySprite.sprite = enemyStats.sprite;
            // Check for quests
            questsSO = questDatabase.GetQuest(main.currentStage);

            BattleStarted();
        }
    }

    private void BattleStarted()
    {
        System.Random random = new System.Random();
        int turn = 1;

        int enemyDamage = enemyStats.damage - playerStats.resistance;
        int playerDamage = playerStats.damage - enemyStats.resistance;

        battleOngoing = true;
        while (battleOngoing == true && turn <= 20)
        {
            AddEntry(string.Format("<align=center>Turn {0}</align>", turn));
            Debug.Log(turn + " turn");
            if (playerTurn) // Player turn
            {
                turn++;
                if (playerOnFire > 0) // Player is on fire
                {
                    int fireDamage = enemyStats.damage / 10;
                    playerStats.health -= fireDamage;
                    AddEntry(string.Format("Turn {0}: <color=green>Player</color> took {1} <color=orange>fire</color> DMG", turn, fireDamage));
                    AddEntry(string.Format("Turn {0}: <color=green>Player</color> has <color=#ff5050>{1} HP</color> remaining", turn, playerStats.health));
                    playerOnFire--;
                }

                int randomNumberFire = random.Next(1, 101);
                int randomNumberFreeze = random.Next(1, 101);
                int randomNumberCounter = random.Next(1, 101);
                int randomNumberCombo = random.Next(1, 101);


                if (playerFrozen == true) // Player is frozen
                {
                    playerFrozen = false;
                    AddEntry(string.Format("Turn {0}: <color=green> Player </color> is <color=lightblue> frozen </color>", turn));
                }
                else
                {
                    do
                    {
                        randomNumberCombo = random.Next(1, 101);
                        randomNumberCounter = random.Next(1, 101);
                        if (randomNumberFire <= playerStats.fireChance && enemyOnFire < 3) // Player sets Enemy on fire
                        {
                            AddEntry(string.Format("Turn {0}: <color=green>Player</color> set <color=red>Enemy</color> on <color=orange>fire</color>", turn));
                            enemyOnFire = 3;
                        }

                        if (randomNumberFreeze <= playerStats.freezeChance && enemyFrozen == false) // Player freezes Enemy
                        {
                            AddEntry(string.Format("Turn {0}: <color=green>Player</color> <color=lightblue>froze </color> <color=red>Enemy</color>", turn));
                            enemyFrozen = true;
                        }

                        //Attack enemy
                        
                        enemyStats.health -= playerDamage;
                        AddEntry(string.Format("Turn {0}: <color=green>Player</color> delt {1} DMG", turn, playerDamage));
                        AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> has <color=#ff5050>{1} HP</color> remaining",turn, enemyStats.health));

                        //Check if enemy Counters
                        if (randomNumberCounter <= enemyStats.counterChance)
                        {
                            
                            playerStats.health -= enemyDamage;
                            AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> Countered and delt {1} DMG", turn, enemyDamage));
                            AddEntry(string.Format("Turn {0}: <color=green>Player</color> has <color=#ff5050>{1} HP</color> remaining", turn, playerStats.health));
                        }

                    } while (randomNumberCombo <= playerStats.comboChance && enemyStats.health > 0);
                }


            }
            else //Enemy turn
            {

                if (enemyOnFire > 0) // Enemy is on fire
                {
                    int fireDamage = playerStats.damage / 10;
                    enemyStats.health -= fireDamage;
                    AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> took {1} <color=orange>fire</color> DMG", turn, fireDamage));
                    AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> has <color=#ff5050>{1} HP</color> remaining", turn, enemyStats.health));
                    enemyOnFire--;
                }

                int randomNumberFire = random.Next(1, 101);
                int randomNumberFreeze = random.Next(1, 101);
                int randomNumberCounter = random.Next(1, 101);
                int randomNumberCombo = random.Next(1, 101);


                if (enemyFrozen == true) // Enemy is frozen
                {
                    enemyFrozen = false;
                    AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> is <color=lightblue>frozen</color>", turn));
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
                            AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> set <color=green>Player</color> on <color=orange>fire</color>", turn));
                        }

                        if (randomNumberFreeze <= enemyStats.freezeChance && playerFrozen == false) // Enemy freezes Player
                        {
                            playerFrozen = true;
                            AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> <color=lightblue>froze</color> <color=green>Player</color>", turn));
                        }

                        //Attack player
                        playerStats.health -= enemyDamage;
                        AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> delt {1} DMG", turn, enemyDamage));
                        AddEntry(string.Format("Turn {0}: <color=green>Player</color> has <color=#ff5050>{1} HP</color> remaining", turn, playerStats.health));
                        //Check if player Counters
                        if (randomNumberCounter <= playerStats.counterChance)
                        {
                            enemyStats.health -= (playerStats.damage - enemyStats.resistance);
                            AddEntry(string.Format("Turn {0}: <color=green>Player</color> Countered and delt {1} DMG", turn, playerDamage));
                            AddEntry(string.Format("Turn {0}: <color=red>Enemy</color> has <color=#ff5050>{1} HP</color> remaining", turn, enemyStats.health));
                        }

                    } while (randomNumberCombo <= enemyStats.comboChance && playerStats.health > 0);
                }

            }

            // Check if the battle is over
            if (playerStats.health <= 0) // Lose
            {
                BattleLost();
            }
            else if (enemyStats.health <= 0) // Win
            {
                BattleWon();
            }

            // Switch turns
            playerTurn = !playerTurn;
            
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
        panelLose.SetActive(true);
        AddEntry(string.Format("Battle Lost"));
    }
    private void BattleWon()
    {
        Debug.Log("Battle Won");
        AddEntry(string.Format("Battle Won!"));
        panelWin.SetActive(true);
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
        main.SavePlayerData();
    }

    public void ShowBattleLog()
    {
        panelTapToClose.SetActive(true);
        battleLog.SetActive(true);
    }

    public void CloseBattleLog()
    {
        panelTapToClose.SetActive(false);
        battleLog.SetActive(false);
    }

    private void AddEntry(string message)
    {
        GameObject entry = Instantiate(battleLogEntryPrefab, battleLogContent);
        entry.GetComponent<TextMeshProUGUI>().text = message;
    }

    public EnemyStatsSO SetEnemyStats(int island, int stage)
    {
        EnemyStatsSO enemy = EnemyDatabase.instance.GetEnemy(island, stage);
        return enemy;
    }
}
