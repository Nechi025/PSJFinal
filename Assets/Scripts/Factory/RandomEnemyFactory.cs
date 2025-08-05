using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyFactory : IEnemyFactory
{
    private EnemyPrototype prototype;

    public RandomEnemyFactory(EnemyPrototype prototype)
    {
        this.prototype = prototype;
    }

    public GameObject CreateEnemy(Vector3 spawnPosition)
    {
        GameObject enemy = prototype.Clone();
        enemy.transform.position = spawnPosition;

        EnemyController controller = enemy.GetComponent<EnemyController>();

        // Estrategia aleatoria
        int r = Random.Range(0, 3); // 3 estrategias por ahora
        switch (r)
        {
            case 0:
                controller.strategyType = EnemyController.StrategyType.ToChest;
                controller.moveSpeed = 2f;
                break;
            case 1:
                controller.strategyType = EnemyController.StrategyType.ToPlayer;
                controller.moveSpeed = 3.5f;
                break;
            case 2:
                controller.strategyType = EnemyController.StrategyType.ZigZagToChest;
                controller.moveSpeed = 2.5f;
                break;
        }

        return enemy;
    }
}
