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
public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public Main main;

    public GameObject questWindow;
    public TMP_Text titleText;
    public TMP_Text objectiveText;
    public TMP_Text hourglassRewardText;

    public void UpdateQuestWindow()
    {
        titleText.text = quest.title;
        objectiveText.text = quest.objective;
        if (quest.hourglassReward > 0)
        {
            hourglassRewardText.text = quest.hourglassReward.ToString();
        }

    }
    public void SetQuest(int number)
    {
        QuestsSO quest = QuestDatabase.instance.GetQuest(number);
        
    }
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
}
public enum GoalType
{
    GenerateItem,
    ReachLevel,
    ReachStage
}
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
        quest1.objective = "<color=red>"+ quest1.currentAmount + "/<color=white>"+ quest1.requiredAmount;
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
