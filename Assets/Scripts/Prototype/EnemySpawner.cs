using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype enemyPrototype;
    public Transform[] spawnPoints;

    /*private EnemyDataFactory enemyDataFactory;
    private IEnemyFactory randomFactory;

    [Header("Waves")]
    public int baseEnemiesPerWave = 5;
    public float spawnInterval = 1f;
    public float waveInterval = 5f;
    public float speedMultiplierPerWave = 0.1f;
    public int maxEnemiesPerWave = 20;

    private int currentWave = 0;*/


    void Start()
    {
        GameFacade.Instance.InitializeSpawner(this);
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            yield return GameFacade.Instance.SpawnWave();
        }
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            randomFactory.CreateEnemy(pos);
        }
    }*/
}
