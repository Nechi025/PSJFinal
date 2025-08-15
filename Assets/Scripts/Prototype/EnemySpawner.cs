using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype enemyPrototype;
    public Transform[] spawnPoints;

    private EnemyDataFactory enemyDataFactory;
    private IEnemyFactory randomFactory;

    [Header("Waves")]
    public int baseEnemiesPerWave = 5;
    public float spawnInterval = 1f;
    public float waveInterval = 5f;
    public float speedMultiplierPerWave = 0.1f;
    public int maxEnemiesPerWave = 20;

    private int currentWave = 0;


    void Start()
    {
        enemyDataFactory = new EnemyDataFactory();
        randomFactory = new RandomEnemyFactory(enemyPrototype, enemyDataFactory);

        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++;

            int enemiesThisWave = Mathf.Min(baseEnemiesPerWave + currentWave, maxEnemiesPerWave);

            for (int i = 0; i < enemiesThisWave; i++)
            {
                Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                GameObject ghost = randomFactory.CreateEnemy(pos);

                //Aumento velocidad del enemigo en base a la velocidad entre oleadas
                EnemyController controller = ghost.GetComponent<EnemyController>();
                controller.moveSpeed += controller.moveSpeed * speedMultiplierPerWave * currentWave;

                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(waveInterval);
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
