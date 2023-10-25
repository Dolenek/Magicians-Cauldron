using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DungeonsManager : MonoBehaviour
{
    [SerializeField] private Button buttonAttack;
    [SerializeField] private List<EnemyStatsSO> enemyStatsList; // List to hold all the different enemy stats
    [SerializeField] private GameObject panelAttack;
    [SerializeField] private TMP_Text textStage;

    private const int maxIslandLevel = 1; // Replace with your own value
    private const int maxStageLevel = 5; // Replace with your own value
    public int islandLevel = 1;

    private BattleManager battleManager;
    private Dictionary<int, List<EnemyStatsSO>> enemyStatsByIsland = new Dictionary<int, List<EnemyStatsSO>>();

    private void Start()
    {
        battleManager = GetComponent<BattleManager>();
        
        // Populate the dictionary with enemy stats for each island and stage
        for (int islandLevel = 1; islandLevel <= maxIslandLevel; islandLevel++)
        {
            List<EnemyStatsSO> enemyStatsForIsland = new List<EnemyStatsSO>();
            for (int stageLevel = 1; stageLevel <= maxStageLevel; stageLevel++)
            {
                // Load the EnemyStatsSO object for the current island and stage level
                EnemyStatsSO enemyStats = Resources.Load<EnemyStatsSO>("EnemiesSO/Enemy" + islandLevel + "-" + stageLevel);
                enemyStatsForIsland.Add(enemyStats);
                if (enemyStats == null)
                {
                    Debug.LogError("ERROR AAAAAAAAAAAA EnemiesSO/Enemy" + islandLevel + "-" + stageLevel);
                }
            }
            enemyStatsByIsland.Add(islandLevel ,enemyStatsForIsland);
        }
    }

    // Method to access and manage enemy data
    public EnemyStatsSO GetEnemyStats(int islandLevel, int stageLevel)
    {
        Debug.Log("GetEnemyStats: " + islandLevel + " " + stageLevel);
        if (enemyStatsByIsland.ContainsKey(islandLevel) && stageLevel - 1 < enemyStatsByIsland[islandLevel].Count)
        {
            return enemyStatsByIsland[islandLevel][stageLevel - 1];
        }
        else
        {
            // Handle the case when the specified key is not found
            Debug.LogError("Enemy stats not found for Island: " + islandLevel + " and Stage: " + stageLevel);
            return null;
        }
    }

    public void ShowAttackPanel(int islandLevel)
    {

        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());
        EnemyStatsSO enemyStatsNew = GetEnemyStats((islandLevel), battleManager.stage);

        textStage.text = "Stage: " + battleManager.stage.ToString();
    }
    private void Attack()
    {

    }
}
