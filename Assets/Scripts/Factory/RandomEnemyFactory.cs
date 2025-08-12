using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyFactory : IEnemyFactory
{
    private EnemyPrototype prototype;
    private EnemyDataFactory enemyDataFactory;

    public RandomEnemyFactory(EnemyPrototype prototype, EnemyDataFactory dataFactory)
    {
        this.prototype = prototype;
        this.enemyDataFactory = dataFactory;
    }

    public GameObject CreateEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = prototype.Clone();
        enemy.transform.position = spawnPosition;

        EnemyController controller = enemy.GetComponent<EnemyController>();

        int r = Random.Range(0, 3);
        string type = r switch
        {
            0 => "Basic",
            1 => "Fast",
            2 => "ZigZag",
            _ => "Basic"
        };

        EnemyData data = enemyDataFactory.GetEnemyData(type);

        controller.strategyType = (EnemyController.StrategyType)r;
        controller.Initialize(data);

        return enemy;
    }
}
