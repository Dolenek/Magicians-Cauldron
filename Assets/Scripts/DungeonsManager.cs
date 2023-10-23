using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DungeonsManager : MonoBehaviour
{
    [SerializeField] private Button buttonAttack;
    [SerializeField] private List<EnemyStatsSO> enemyStatsList; // List to hold all the different enemy stats
    [SerializeField] private GameObject panelAttack;
    private BattleManager battleManager;

    private int islandLevel = 1;
    private int stageLevel = 1;

    private void Start()
    {
        battleManager = GetComponent<BattleManager>();
    }

    // Method to access and manage enemy data
    public EnemyStatsSO GetEnemyStats(int islandLevel, int stageLevel)
    {
        foreach (EnemyStatsSO enemyStats in enemyStatsList)
        {
            if (enemyStats.island == islandLevel && enemyStats.stage == stageLevel)
            {
                return enemyStats;
            }
        }
        return null; // If the enemy stats for the specified island and stage are not found
    }

    public void ShowAttackPanel(int islandLevel)
    {
        
        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());
        EnemyStatsSO enemyStatsNew = GetEnemyStats((GetIslandLevel()), battleManager.stage);
    }
    private void Attack()
    {

    }
    public void IslandGetLevel(int islandLevel)
    {

    }
    public int GetIslandLevel()
    {
        return islandLevel;
    }
    private int GetStageLevel()
    {
        return stageLevel;
    }
}
