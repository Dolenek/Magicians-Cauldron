using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour
{
    public static QuestDatabase instance;

    public List<QuestsSO> quests;
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
    private void Start()
    {
        QuestsSO quest1 = ScriptableObject.CreateInstance<QuestsSO>();
        quest1.number = 1;
        quest1.title = "Generate 5 items";
        quest1.objective = "<color=red>" + quest1.currentAmount + "/<color=white>" + quest1.requiredAmount;
        quest1.goal.goalType = GoalType.GenerateItem;
        quest1.goal.requiredAmount = 5;
        quest1.hourglass = 10;
        quests.Add(quest1);

        QuestsSO quest2 = ScriptableObject.CreateInstance<QuestsSO>();
        quest2.number = 2;
        quest2.goal.goalType = GoalType.GenerateItem;
        quest2.goal.requiredAmount = 10;
        quest2.hourglass = 20;
        quests.Add(quest2);
    }
}
