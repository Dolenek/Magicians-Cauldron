using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    public int island = 1;
    public int stage = 1;

    public int health = 6;
    public int damage = 6;
    public int speed = 6;
    public int resistance = 6;
    public float comboChance = 0f;
    public float counterChance = 0f;
    public float freezeChance = 0f;
    public float fireChance = 0f;

    public int hourglass;

    public Sprite sprite;

}
