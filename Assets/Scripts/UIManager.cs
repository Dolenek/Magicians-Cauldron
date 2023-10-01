using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textPlayerHealth;
    [SerializeField] private TMP_Text textPlayerDamage;
    [SerializeField] private TMP_Text textPlayerResistance;
    [SerializeField] private TMP_Text textPlayerSpeed;
    [SerializeField] private TMP_Text textPlayerCounter;
    [SerializeField] private TMP_Text textPlayerCombo;
    [SerializeField] private TMP_Text textPlayerFreeze;
    [SerializeField] private TMP_Text textPlayerFire;


    private Main main;

    // Initialize itemGenerator in Start or Awake
    private void Awake()
    {
        // Try to find the ItemGenerator component on the Player GameObject
        main = GetComponent<Main>();

        // If it's still null, create and attach the component
        if (main == null)
        {
            main = gameObject.AddComponent<Main>();
        }
    }
}
