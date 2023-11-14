using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-95)]
public class EnemyDatabase : MonoBehaviour
{
    public static EnemyDatabase instance;

    public List<EnemyStatsSO> enemies;

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

    public EnemyStatsSO GetEnemy(int island, int stage)
    {
        foreach (EnemyStatsSO enemy in enemies)
        {
            if (enemy.island == island && enemy.stage == stage)
            {
                return enemy;

            }
        }
        return null;
    }

    private void Start()
    {
        EnemyStatsSO enemy1S1 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S1.island = 1;
        enemy1S1.stage = 1;
        enemy1S1.name = "Enemy 1";
        enemy1S1.health = 100;
        enemy1S1.damage = 12;
        enemy1S1.hourglass = 10;
        enemies.Add(enemy1S1);

        EnemyStatsSO enemy1S2 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S2.island = 1;
        enemy1S2.stage = 2;
        enemy1S2.name = "Enemy 2";
        enemy1S2.health = 150;
        enemy1S2.damage = 15;
        enemy1S2.hourglass = 10;
        enemies.Add(enemy1S2);

        EnemyStatsSO enemy1S3 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S3.island = 1;
        enemy1S3.stage = 3;
        enemy1S3.name = "Enemy 3";
        enemy1S3.health = 200;
        enemy1S3.damage = 20;
        enemy1S3.hourglass = 10;
        enemies.Add(enemy1S3);

        EnemyStatsSO enemy1S4 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S4.island = 1;
        enemy1S4.stage = 4;
        enemy1S4.name = "Enemy 4";
        enemy1S4.health = 250;
        enemy1S4.damage = 25;
        enemy1S4.hourglass = 10;
        enemies.Add(enemy1S4);

        EnemyStatsSO enemy1S5 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S5.island = 1;
        enemy1S5.stage = 5;
        enemy1S5.name = "Enemy 5";
        enemy1S5.health = 300;
        enemy1S5.damage = 30;
        enemy1S5.hourglass = 10;
        enemies.Add(enemy1S5);

        EnemyStatsSO enemy1S6 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S6.island = 1;
        enemy1S6.stage = 6;
        enemy1S6.name = "Enemy 6";
        enemy1S6.health = 350;
        enemy1S6.damage = 35;
        enemy1S6.hourglass = 10;
        enemies.Add(enemy1S6);
    }
}
