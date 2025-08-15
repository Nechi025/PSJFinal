using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDataFactory
{
    private Dictionary<string, EnemyData> enemyDataPool = new Dictionary<string, EnemyData>();

    public EnemyData GetEnemyData(string type)
    {
        if (enemyDataPool.ContainsKey(type))
        {
            return enemyDataPool[type];
        }
        else
        {
            EnemyData newData = CreateEnemyData(type);
            enemyDataPool[type] = newData;
            return newData;
        }
    }

    private EnemyData CreateEnemyData(string type)
    {
        EnemyData data = new EnemyData();

        switch (type)
        {
            case "Basic":
                data.sprite = Resources.Load<Sprite>("Sprites/Skull");
                data.baseSpeed = 2f;
                break;
            case "Fast":
                data.sprite = Resources.Load<Sprite>("Sprites/Axe");
                data.baseSpeed = 3.5f;
                break;
            case "ZigZag":
                data.sprite = Resources.Load<Sprite>("Sprites/Eye");
                data.baseSpeed = 2.5f;
                break;
            default:
                data.sprite = null;
                data.baseSpeed = 2f;
                break;
        }

        return data;
    }
}
