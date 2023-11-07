using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest")]
public class QuestsSO : ScriptableObject
{
    public int number;

    public QuestGoal goal;
    public string title;
    public string objective;
    public int currentAmount;
    public int requiredAmount;
    public int hourglass;

    //public Sprite sprite;

}
