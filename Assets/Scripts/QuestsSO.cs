using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class QuestsSO : ScriptableObject
{
    public int number;
    public string title;
    public string objective;
    public int currentAmount;
    public int requiredAmount;
    public int hourglass;
    public GoalType goalType;
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
    //public Sprite sprite;

}
public enum GoalType
{
    GenerateItem,
    ReachLevel,
    ReachStage
}