using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyFactory : IEnemyFactory
{
    private EnemyPrototype prototype;

    public FastEnemyFactory(EnemyPrototype prototype)
    {
        this.prototype = prototype;
    }

    public GameObject CreateEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = prototype.Clone();
        enemy.transform.position = spawnPosition;

        var controller = enemy.GetComponent<EnemyController>();
        controller.strategyType = EnemyController.StrategyType.ToPlayer;
        controller.moveSpeed = 4f;

        return enemy;
    }
}
