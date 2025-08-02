using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype basicEnemy;
    public EnemyPrototype fastEnemy;

    private IEnemyFactory basicFactory;
    private IEnemyFactory fastFactory;

    public Transform[] spawnPoints;

    void Start()
    {
        basicFactory = new BasicEnemyFactory(basicEnemy);
        fastFactory = new FastEnemyFactory(fastEnemy);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Vector3 pos = GetRandomSpawn();
            basicFactory.CreateEnemy(pos);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Vector3 pos = GetRandomSpawn();
            fastFactory.CreateEnemy(pos);
        }
    }

    Vector3 GetRandomSpawn()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
