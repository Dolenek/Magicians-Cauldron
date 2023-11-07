using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
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
