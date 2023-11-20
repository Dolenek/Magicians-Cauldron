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
    [SerializeField] private Image imageReward1;
    [SerializeField] private Image imageReward2;

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
        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());
        Debug.Log(main.currentStage + " ShowAttackPanel DungeonsManager");
        textStage.text = "Stage: " + main.currentStage.ToString();

        enemyStats = SetEnemyStats(islandLevel, main.currentStage);
        //textEnemyLvl.text = "Lvl: " + enemyStats.level.ToString();
        imageEnemy.sprite = enemyStats.sprite;
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
