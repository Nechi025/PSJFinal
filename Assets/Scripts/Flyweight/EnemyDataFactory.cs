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
            // Aquí podrías cargar datos desde ScriptableObjects o crear en tiempo real
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
                data.sprite = Resources.Load<Sprite>("Assets/Sprites/Skull");
                data.color = Color.red;
                data.baseSpeed = 2f;
                break;
            case "Fast":
                data.sprite = Resources.Load<Sprite>("Assets/Sprites/Axe");
                data.color = Color.yellow;
                data.baseSpeed = 3.5f;
                break;
            case "ZigZag":
                data.sprite = Resources.Load<Sprite>("Assets/Sprites/Eye");
                data.color = Color.blue;
                data.baseSpeed = 2.5f;
                break;
            default:
                data.sprite = null;
                data.color = Color.white;
                data.baseSpeed = 2f;
                break;
        }

        return data;
    }
}
