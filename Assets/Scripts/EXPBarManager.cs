using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPBarManager : MonoBehaviour
{
    [SerializeField] private Slider barEXP;      // Reference to the UI Slider representing the exp bar
    [SerializeField] private TMP_Text textLevel; // Reference to a UI Text element displaying the player's level
    [SerializeField] private TMP_Text textEXP;   // Reference to an UI 
    [SerializeField] private int maxXP = 100;    // Maximum XP needed to reach the next level
    [SerializeField] private int currentXP = 0;  // Current XP

    private Main main;

    private void Awake()
    {
        main = GetComponent<Main>();
    }

    private void Start()
    {
        UpdateExpBar();
    }

    public void UpdateExpBar()
    {
        float fillAmount = currentXP / maxXP;
        textEXP.text = currentXP.ToString() + "/" + maxXP.ToString();
        barEXP.value = fillAmount;
        textLevel.text = "Lv. " + main.playerLevel.ToString();
    }

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;

        if (currentXP >= maxXP)
        {
            // Level up
            main.playerLevel++;
            currentXP -= maxXP;
            maxXP = CalculateNextLevelXP(); // Implement a function to calculate the XP required for the next level
            UpdateExpBar();
        }
        else
        {
            UpdateExpBar();
        }
        
    }

    int CalculateNextLevelXP()
    {
        return (int)(maxXP * 1.2f);
    }

}


