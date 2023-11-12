using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-90)]
public class QuestDatabase : MonoBehaviour
{
    public static QuestDatabase instance;

    public List<QuestsSO> quests;
    public QuestsSO questsSO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("QuestDatabase Started");

        QuestsSO quest1 = ScriptableObject.CreateInstance<QuestsSO>();
        quest1.number = 1;
        quest1.goalType = GoalType.GenerateItem;
        quest1.title = "Generate 5 items";
        quest1.requiredAmount = 5;
        quest1.hourglass = 10;
        quests.Add(quest1);

        QuestsSO quest2 = ScriptableObject.CreateInstance<QuestsSO>();
        quest2.number = 2;
        quest2.goalType = GoalType.GenerateItem;
        quest2.title = "Generate 10 more items";
        quest2.requiredAmount = 10;
        quest2.hourglass = 20;
        quests.Add(quest2);

        QuestsSO quest3 = ScriptableObject.CreateInstance<QuestsSO>();
        quest3.number = 3;
        quest3.goalType = GoalType.ReachLevel;
        quest3.title = "Reach Level 3";
        quest3.requiredAmount = 3;
        quest3.hourglass = 30;
        quests.Add(quest3);

        QuestsSO quest4 = ScriptableObject.CreateInstance<QuestsSO>();
        quest4.number = 4;
        quest4.goalType = GoalType.ReachLevel;
        quest4.title = "Reach Level 100";
        quest4.requiredAmount = 100;
        quest4.hourglass = 666;
        quests.Add(quest4);
    }


    public QuestsSO GetQuest(int questNumber)
    {
        foreach (QuestsSO quest in quests)
        {
            if (quest.number == questNumber)
            {
                Debug.Log("Quest Loaded via GetQuest: " + quest.number);
                return quest;
            }
        }
        return null;
    }
}
