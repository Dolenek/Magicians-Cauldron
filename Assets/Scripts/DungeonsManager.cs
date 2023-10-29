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

    private BattleManager battleManager;

    private void Awake()
    {
        battleManager = GetComponent<BattleManager>();
        battleManager.stage = PlayerPrefs.GetInt("CurrentStage");
    }

    public void ShowAttackPanel()
    {
        panelAttack.SetActive(true);
        buttonAttack.onClick.AddListener(() => Attack());

        textStage.text = "Stage: " + battleManager.stage.ToString();

        battleManager.SetEnemies(islandLevel, battleManager.stage);

    }

    private void Attack()
    {

    }
}
