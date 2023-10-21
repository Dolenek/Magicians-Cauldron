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
        EnemyStatsSO enemyStats = GetEnemyStats(islandLevel, battleManager.stage);
    }
    private void Attack()
    {

    }
    private int GetStageLevel()
    {
        return 1;
    }
}
