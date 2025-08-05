using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagEnemyFactory : IEnemyFactory
{
    private EnemyPrototype prototype;

    public ZigZagEnemyFactory(EnemyPrototype prototype)
    {
        this.prototype = prototype;
    }

    public GameObject CreateEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = prototype.Clone();
        enemy.transform.position = spawnPosition;

        EnemyController controller = enemy.GetComponent<EnemyController>();
        controller.strategyType = EnemyController.StrategyType.ZigZagToChest;

        return enemy;
    }
}
