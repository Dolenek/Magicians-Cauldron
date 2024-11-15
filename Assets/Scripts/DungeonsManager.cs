using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DungeonsManager : MonoBehaviour
{
    [SerializeField] private Button buttonAttack;
    [SerializeField] private Button buttonIsland1;
    [SerializeField] private Button buttonEnemyStats;
    [SerializeField] private GameObject panelAttack;
    [SerializeField] private TMP_Text textStage;
    [SerializeField] private TMP_Text textEnemyLvl;
    [SerializeField] private Image imageIslandBackground;
    [SerializeField] private Image imageEnemy;
    [SerializeField] private GameObject reward1;
    [SerializeField] private GameObject reward2;
    [SerializeField] private TMP_Text textReward1;
    [SerializeField] private TMP_Text textReward2;


    [SerializeField] private Sprite[] islandBackgrounds;

    public int islandLevel = 1;

    private Main main;
    private BattleManager battleManager;
    private EnemyStatsSO enemyStats;
    private EnemyDatabase enemyDatabase;
    private QuestDatabase questDatabase;
    private QuestsSO questsSO;

    private void Awake()
    {
        battleManager = GetComponent<BattleManager>();
        main = GetComponent<Main>();
        questDatabase = GetComponent<QuestDatabase>();
        enemyDatabase = GetComponent<EnemyDatabase>();
        if (main == null)
            main = gameObject.AddComponent<Main>();
        if (battleManager == null)
            battleManager = gameObject.AddComponent<BattleManager>();
        if (questDatabase == null)
            questDatabase = gameObject.AddComponent<QuestDatabase>();
        if (enemyDatabase == null)
            enemyDatabase = gameObject.AddComponent<EnemyDatabase>();
    }
    private void Start()
    {
        enemyDatabase.GetEnemy(islandLevel, main.currentStage);
    }
    public void ShowAttackPanel()
    {
        main.LoadPlayerData();
        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());
        Debug.Log(main.currentStage + " ShowAttackPanel DungeonsManager");
        textStage.text = "Stage: " + main.currentStage.ToString();

        enemyStats = SetEnemyStats(islandLevel, main.currentStage);
        
        imageEnemy.sprite = enemyStats.sprite;
        imageIslandBackground.sprite = islandBackgrounds[islandLevel - 1];
        if (enemyStats.level > 0)
        {
            textEnemyLvl.text = "Lvl: " + enemyStats.level.ToString();
        }
        else
        {
            textEnemyLvl.text = "Lvl: " + enemyStats.stage.ToString();
        }
        if (enemyStats.hourglass > 0)
        {
            reward1.SetActive(true);
            textReward1.text = enemyStats.hourglass.ToString();
        }
        else
        {
            reward1.SetActive(false);
        }
        if (enemyStats.anvilSkip > 0)
        {
            reward2.SetActive(true);
            textReward2.text = enemyStats.anvilSkip.ToString();
        }
        else
        {
            reward2.SetActive(false);
        }

    }

    private void Attack()
    {

    }
    private EnemyStatsSO SetEnemyStats(int island, int stage)
    {
        EnemyStatsSO enemy = EnemyDatabase.instance.GetEnemy(island, stage);
        return enemy;
    }
}
