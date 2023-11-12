using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class DungeonsManager : MonoBehaviour
{
    [SerializeField] private Button buttonAttack;
    [SerializeField] private Button buttonIsland1;
    [SerializeField] private GameObject panelAttack;
    [SerializeField] private TMP_Text textStage;

    public int islandLevel = 1;

    private Main main;
    private BattleManager battleManager;

    private void Awake()
    {
        battleManager = GetComponent<BattleManager>();
        main = GetComponent<Main>();
        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
    }

    public void ShowAttackPanel()
    {
        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());
        Debug.Log(main.currentStage + " ShowAttackPanel DungeonsManager");
        textStage.text = "Stage: " + main.currentStage.ToString();

        battleManager.SetEnemyStats(islandLevel, main.currentStage);

    }

    private void Attack()
    {

    }
}
