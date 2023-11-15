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
    [SerializeField] public int maxXP = 60;    // Maximum XP needed to reach the next level

    private Main main;

    private void Awake()
    {
        main = GetComponent<Main>();
    }

    private void Start()
    {
        
        maxXP = (int)(main.playerLevel * 100 * 0.6f);
        UpdateExpBar();
    }

    public void UpdateExpBar()
    {
        float fillAmount = (float)main.playerCurrentEXP / (float)maxXP;
        textEXP.text = main.playerCurrentEXP.ToString() + "/" + maxXP.ToString();
        barEXP.value = fillAmount;
        textLevel.text = "Lv. " + main.playerLevel.ToString();
    }

    public void GainXP(int xpAmount)
    {
        main.playerCurrentEXP += xpAmount;

        if (main.playerCurrentEXP >= maxXP)
        {
            // Level up
            main.playerLevel++;
            main.playerCurrentEXP -= maxXP;
            maxXP = CalculateNextLevelXP(main.playerLevel); // Implement a function to calculate the XP required for the next level
            UpdateExpBar();
        }
        else
        {
            UpdateExpBar();
        }
        
    }

    int CalculateNextLevelXP(int playerLevel)
    {
        return (int)(playerLevel * 100 * 0.6f);
    }

}


