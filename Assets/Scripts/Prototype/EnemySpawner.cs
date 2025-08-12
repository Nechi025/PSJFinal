using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype enemyPrototype;
    public Transform[] spawnPoints;

    private EnemyDataFactory enemyDataFactory;
    private IEnemyFactory randomFactory;

    void Start()
    {
        enemyDataFactory = new EnemyDataFactory();
        randomFactory = new RandomEnemyFactory(enemyPrototype, enemyDataFactory);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            randomFactory.CreateEnemy(pos);
        }
    }
}
