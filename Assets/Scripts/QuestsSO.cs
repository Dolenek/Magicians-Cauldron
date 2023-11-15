using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-89)]
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

    
    //public Sprite sprite;

}
public enum GoalType
{
    GenerateItem,
    GenerateNewItem,
    GenerateRareItem,
    ReachLevel,
    ReachStage
}