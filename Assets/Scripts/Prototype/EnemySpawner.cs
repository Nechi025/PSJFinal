using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype basicEnemy;
    public EnemyPrototype fastEnemy; 
    public EnemyPrototype zigzagEnemy;

    public EnemyPrototype randomEnemy;

    private IEnemyFactory basicFactory;
    private IEnemyFactory fastFactory;
    private IEnemyFactory zigzagFactory;

    private IEnemyFactory randomFactory;
    

    public Transform[] spawnPoints;

    void Start()
    {
        basicFactory = new BasicEnemyFactory(basicEnemy);
        fastFactory = new FastEnemyFactory(fastEnemy);
        zigzagFactory = new ZigZagEnemyFactory(zigzagEnemy);
        randomFactory = new RandomEnemyFactory(randomEnemy);
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

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Vector3 pos = GetRandomSpawn();
            zigzagFactory.CreateEnemy(pos);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 pos = GetRandomSpawn();
            randomFactory.CreateEnemy(pos);
        }
    }

    Vector3 GetRandomSpawn()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].position;
    }
}
