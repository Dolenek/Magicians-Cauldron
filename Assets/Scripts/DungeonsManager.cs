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
        EnemyStatsSO enemyStatsNew = GetEnemyStats((islandLevel), battleManager.stage);
        
        textStage.text = "Stage: " + battleManager.stage.ToString();
    }
    private void Attack()
    {

    }
}
