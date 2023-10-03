using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBarManager : MonoBehaviour
{
    public Slider expBar;       // Reference to the UI Slider representing the exp bar
    public Text levelText;      // Reference to a UI Text element displaying the player's level
    public int maxXP = 100;     // Maximum XP needed to reach the next level
    public int currentXP = 0;   // Current XP
    public int currentLevel = 1; // Current player level

    public void UpdateExpBar()
    {
        float fillAmount = (float)currentXP / maxXP;
        expBar.value = fillAmount;
        levelText.text = "Level " + currentLevel;
    }

    public void GainXP(int xpAmount)
    {
        currentXP += xpAmount;

        if (currentXP >= maxXP)
        {
            // Level up
            currentLevel++;
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
        // Implement your logic for calculating the XP required for the next level
        // This could be a simple formula or a more complex system.
        // Example: return (int)(maxXP * 1.5f);
        return 100; // Replace with your calculation
    }

    //expBarManager.GainXP(20); // Gain 20 XP
}


