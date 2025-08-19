using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype enemyPrototype;
    public Transform[] spawnPoints;

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
}
