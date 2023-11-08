using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Quest
{
    public bool isActive;

    public string title;
    public string objective;
    public int hourglassReward;

    public QuestGoal goal;
}
[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
    public void ItemGenerated()
    {
        if (goalType == GoalType.GenerateItem)
        {
            currentAmount++;
        }
    }
    public void StageReached()
    {
        if (goalType == GoalType.ReachStage)
        {
            currentAmount++;
        }   
    }
    public void LevelReached()
    {
        if (goalType == GoalType.ReachLevel)
        {
            
        }
    }   
    public void NewItemGenerated()
    {
        if (goalType == GoalType.GenerateItem)
        {
            currentAmount++;
        }
    }
}
public enum GoalType
{
    GenerateItem,
    ReachLevel,
    ReachStage
}


