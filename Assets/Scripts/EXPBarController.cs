using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPBarController : MonoBehaviour
{
    [SerializeField] private Slider expSliderBar;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private TMP_Text textExp;

    [SerializeField] private float currentExp = 0;
    [SerializeField] public int currentLevel = 1;
    [SerializeField] private float maxExp = 100;

    public static EXPBarController instance; // Stará se o to, že je tøída pøístupná i z ostatních tøíd

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

    private void Start()
    {
        UpdateExpBar();
        
    }

    public void GainExp(int expAmount)
    {
        currentExp += expAmount;
        if (currentExp >= maxExp) 
        {
            LevelUp();
            maxExp += maxExp / 5;
        }
        
        UpdateExpBar();
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExp = 0;
        textLevel.text = string.Format("Lv. {0}", currentLevel);

    }

    private void UpdateExpBar()
    {
        expSliderBar.value = (float)currentExp / maxExp;
        textExp.text = string.Format("{0}/{1}",currentExp,maxExp);
        textLevel.text = string.Format("Lv. {0}", currentLevel);
    }
}
