using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-95)]
public class EnemyDatabase : MonoBehaviour
{
    [Header("1st Island Sprites")]
    [SerializeField] Sprite[] enemySprites1stIsland;
    [Header("2nd Island Sprites")]
    [SerializeField] Sprite[] enemySprites2ndIsland;
    [Header("3rd Island Sprites")]
    [SerializeField] Sprite[] enemySprites3ndIsland;
    [Header("4th Island Sprites")]
    [SerializeField] Sprite[] enemySprites4ndIsland;
    [Header("5th Island Sprites")]
    [SerializeField] Sprite[] enemySprites5ndIsland;


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
        enemy1S1.sprite = enemySprites1stIsland[0];
        enemies.Add(enemy1S1);

        EnemyStatsSO enemy1S2 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S2.island = 1;
        enemy1S2.stage = 2;
        enemy1S2.name = "Enemy 2";
        enemy1S2.health = 150;
        enemy1S2.damage = 15;
        enemy1S2.hourglass = 10;
        enemy1S2.sprite = enemySprites1stIsland[1];
        enemies.Add(enemy1S2);

        EnemyStatsSO enemy1S3 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S3.island = 1;
        enemy1S3.stage = 3;
        enemy1S3.name = "Enemy 3";
        enemy1S3.health = 200;
        enemy1S3.damage = 20;
        enemy1S3.hourglass = 10;
        enemy1S3.sprite = enemySprites1stIsland[2];
        enemies.Add(enemy1S3);

        EnemyStatsSO enemy1S4 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S4.island = 1;
        enemy1S4.stage = 4;
        enemy1S4.name = "Enemy 4";
        enemy1S4.health = 250;
        enemy1S4.damage = 25;
        enemy1S4.hourglass = 10;
        enemy1S4.sprite = enemySprites1stIsland[3];
        enemies.Add(enemy1S4);

        EnemyStatsSO enemy1S5 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S5.island = 1;
        enemy1S5.stage = 5;
        enemy1S5.name = "Enemy 5";
        enemy1S5.health = 300;
        enemy1S5.damage = 30;
        enemy1S5.hourglass = 10;
        enemy1S5.sprite = enemySprites1stIsland[4];
        enemies.Add(enemy1S5);

        EnemyStatsSO enemy1S6 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S6.island = 1;
        enemy1S6.stage = 6;
        enemy1S6.name = "Enemy 6";
        enemy1S6.health = 350;
        enemy1S6.damage = 35;
        enemy1S6.hourglass = 10;
        enemy1S6.sprite = enemySprites1stIsland[1];
        enemies.Add(enemy1S6);

        EnemyStatsSO enemy1S7 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S7.island = 1;
        enemy1S7.stage = 7;
        enemy1S7.name = "Enemy 7";
        enemy1S7.health = 400;
        enemy1S7.damage = 40;
        enemy1S7.hourglass = 10;
        enemy1S7.sprite = enemySprites1stIsland[2];
        enemies.Add(enemy1S7);

        EnemyStatsSO enemy1S8 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S8.island = 1;
        enemy1S8.stage = 8;
        enemy1S8.name = "Enemy 8";
        enemy1S8.health = 450;
        enemy1S8.damage = 45;
        enemy1S8.hourglass = 10;
        enemy1S8.sprite = enemySprites1stIsland[3];
        enemies.Add(enemy1S8);

        EnemyStatsSO enemy1S9 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S9.island = 1;
        enemy1S9.stage = 9;
        enemy1S9.name = "Enemy 9";
        enemy1S9.health = 500;
        enemy1S9.damage = 50;
        enemy1S9.hourglass = 10;
        enemy1S9.sprite = enemySprites1stIsland[4];
        enemies.Add(enemy1S9);

        EnemyStatsSO enemy1S10 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S10.island = 1;
        enemy1S10.stage = 10;
        enemy1S10.name = "Enemy 10";
        enemy1S10.health = 550;
        enemy1S10.damage = 55;
        enemy1S10.hourglass = 10;
        enemy1S10.sprite = enemySprites1stIsland[0];
        enemies.Add(enemy1S10);

        EnemyStatsSO enemy1S11 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S11.island = 1;
        enemy1S11.stage = 11;
        enemy1S11.name = "Enemy 11";
        enemy1S11.health = 600;
        enemy1S11.damage = 60;
        enemy1S11.hourglass = 10;
        enemy1S11.sprite = enemySprites1stIsland[2];
        enemies.Add(enemy1S11);

        EnemyStatsSO enemy1S12 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S12.island = 1;
        enemy1S12.stage = 12;
        enemy1S12.name = "Enemy 12";
        enemy1S12.health = 650;
        enemy1S12.damage = 65;
        enemy1S12.hourglass = 10;
        enemy1S12.sprite = enemySprites1stIsland[3];
        enemies.Add(enemy1S12);
            
        EnemyStatsSO enemy1S13 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S13.island = 1;
        enemy1S13.stage = 13;
        enemy1S13.name = "Enemy 13";
        enemy1S13.health = 700;
        enemy1S13.damage = 70;
        enemy1S13.hourglass = 10;
        enemy1S13.sprite = enemySprites1stIsland[4];
        enemies.Add(enemy1S13);

        EnemyStatsSO enemy1S14 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S14.island = 1;
        enemy1S14.stage = 14;
        enemy1S14.name = "Enemy 14";
        enemy1S14.health = 750;
        enemy1S14.damage = 75;
        enemy1S14.hourglass = 10;
        enemy1S14.sprite = enemySprites1stIsland[0];
        enemies.Add(enemy1S14);

        EnemyStatsSO enemy1S15 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S15.island = 1;
        enemy1S15.stage = 15;
        enemy1S15.name = "Enemy 15";
        enemy1S15.health = 800;
        enemy1S15.damage = 80;
        enemy1S15.hourglass = 10;
        enemy1S15.sprite = enemySprites1stIsland[1];
        enemies.Add(enemy1S15);

        EnemyStatsSO enemy1S16 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S16.island = 1;
        enemy1S16.stage = 16;
        enemy1S16.name = "Enemy 16";
        enemy1S16.health = 850;
        enemy1S16.damage = 85;
        enemy1S16.hourglass = 10;
        enemy1S16.sprite = enemySprites1stIsland[3];
        enemies.Add(enemy1S16);

        EnemyStatsSO enemy1S17 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S17.island = 1;
        enemy1S17.stage = 17;
        enemy1S17.name = "Enemy 17";
        enemy1S17.health = 900;
        enemy1S17.damage = 90;
        enemy1S17.hourglass = 10;
        enemy1S17.sprite = enemySprites1stIsland[4];
        enemies.Add(enemy1S17);
        
        EnemyStatsSO enemy1S18 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S18.island = 1;
        enemy1S18.stage = 18;
        enemy1S18.name = "Enemy 18";
        enemy1S18.health = 950;
        enemy1S18.damage = 95;
        enemy1S18.hourglass = 10;
        enemy1S18.sprite = enemySprites1stIsland[0];
        enemies.Add(enemy1S18);

        EnemyStatsSO enemy1S19 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S19.island = 1;
        enemy1S19.stage = 19;
        enemy1S19.name = "Enemy 19";
        enemy1S19.health = 1000;
        enemy1S19.damage = 100;
        enemy1S19.hourglass = 10;
        enemy1S19.sprite = enemySprites1stIsland[1];
        enemies.Add(enemy1S19);

        EnemyStatsSO enemy1S20 = ScriptableObject.CreateInstance<EnemyStatsSO>();
        enemy1S20.island = 1;
        enemy1S20.stage = 20;
        enemy1S20.name = "Enemy 20";
        enemy1S20.health = 100000;
        enemy1S20.damage = 110;
        enemy1S20.comboChance = 0.5f;
        enemy1S20.hourglass = 10;
        enemy1S20.sprite = enemySprites1stIsland[2];
        enemies.Add(enemy1S20);

    }
}
