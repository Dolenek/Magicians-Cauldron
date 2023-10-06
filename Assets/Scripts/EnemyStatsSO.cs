using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    public int island = 1;
    public int stage = 1;

    public int health = 100;
    public int damage = 10;
    public int speed = 20;
    public int resistance = 5;
    public float comboChance = 0f;
    public float counterChance = 0f;
    public float freezeChance = 0f;
    public float fireChance = 0f;
}
