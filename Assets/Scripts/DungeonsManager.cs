using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonsManager : MonoBehaviour
{
    [SerializeField] private Button buttonAttack;
    private void ShowAttackPanel()
    {

        // Show the UI panel with the stats and options
        uiManager.panelEquipOrSell.SetActive(true);
        // Show the stats of newly generated item
        uiManager.ShowNewItemText(newItem);
        // Show the stats of the already equipped item
        uiManager.ShowExistingItemText(existingItemSlotIndex);

        // Remove any existing listeners first
        buttonAttack.onClick.RemoveAllListeners();

        // Add button click events to handle player choice
        buttonAttack.onClick.AddListener(() => Attack());
    }
    private void Attack()
    {

    }
}
