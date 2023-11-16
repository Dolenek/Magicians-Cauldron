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
        quest2.hourglass = 15;
        quests.Add(quest2);

        QuestsSO quest3 = ScriptableObject.CreateInstance<QuestsSO>();
        quest3.number = 3;
        quest3.goalType = GoalType.ReachStage;
        quest3.title = "Reach Stage 5";
        quest3.requiredAmount = 5;
        quest3.hourglass = 10;
        quests.Add(quest3);

        QuestsSO quest4 = ScriptableObject.CreateInstance<QuestsSO>();
        quest4.number = 4;
        quest4.goalType = GoalType.ReachLevel;
        quest4.title = "Reach Level 3";
        quest4.requiredAmount = 3;
        quest4.hourglass = 20;
        quests.Add(quest4);

        QuestsSO quest5 = ScriptableObject.CreateInstance<QuestsSO>();
        quest5.number = 5;
        quest5.goalType = GoalType.GenerateNewItem;
        quest5.title = "Generate 20 new items";
        quest5.requiredAmount = 20;
        quest5.hourglass = 15;
        quests.Add(quest5);

        QuestsSO quest6 = ScriptableObject.CreateInstance<QuestsSO>();
        quest6.number = 6;
        quest6.goalType = GoalType.ReachStage;
        quest6.title = "Reach Stage 10";
        quest6.requiredAmount = 10;
        quest6.hourglass = 20;
        quests.Add(quest6);

        QuestsSO quest7 = ScriptableObject.CreateInstance<QuestsSO>();
        quest7.number = 7;
        quest7.goalType = GoalType.GenerateItem;
        quest7.title = "Generate 25 more items";
        quest7.requiredAmount = 25;
        quest7.hourglass = 30;
        quests.Add(quest7);

        QuestsSO quest8 = ScriptableObject.CreateInstance<QuestsSO>();
        quest8.number = 8;
        quest8.goalType = GoalType.ReachLevel;
        quest8.title = "Reach Stage 5";
        quest8.requiredAmount = 5;
        quest8.hourglass = 10;
        quests.Add(quest8);

        QuestsSO quest9 = ScriptableObject.CreateInstance<QuestsSO>();
        quest9.number = 9;
        quest9.goalType = GoalType.ReachStage;
        quest9.title = "Reach Stage 15";
        quest9.requiredAmount = 15;
        quest9.hourglass = 20;
        quests.Add(quest9);

        QuestsSO quest10 = ScriptableObject.CreateInstance<QuestsSO>();
        quest10.number = 20;
        quest10.goalType = GoalType.ReachLevel;
        quest10.title = "Reach Level 100";
        quest10.requiredAmount = 100;
        quest10.hourglass = 666;
        quests.Add(quest10);
    }


    public QuestsSO GetQuest(int questNumber)
    {
        foreach (QuestsSO quest in quests)
        {
            if (quest.number == questNumber)
            {
                return quest;
            }
        }
        return null;
    }
}
