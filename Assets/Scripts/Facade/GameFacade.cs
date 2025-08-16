using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameFacade : MonoBehaviour, ISubject
{
    public static GameFacade Instance { get; private set; }

    [Header("References")]
    public EventQueueManager eventQueue;
    public HUD hud;
    public PlayerController player;
    public EnemySpawner spawner;

    //Spawner data
    private EnemyDataFactory enemyDataFactory;
    private IEnemyFactory randomFactory;
    private int currentWave = 0;
    private int baseEnemiesPerWave = 5;
    private float spawnInterval = 1f;
    private float waveInterval = 5f;
    private float speedMultiplierPerWave = 0.1f;
    private int maxEnemiesPerWave = 20;

    private List<IObserver> observers = new List<IObserver>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(GameEvent gameEvent)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(gameEvent);
        }
    }

    public void InitializeSpawner(EnemySpawner spawnerRef)
    {
        enemyDataFactory = new EnemyDataFactory();
        randomFactory = new RandomEnemyFactory(spawnerRef.enemyPrototype, enemyDataFactory);
    }

    public IEnumerator SpawnWave()
    {
        currentWave++;
        int enemiesThisWave = Mathf.Min(baseEnemiesPerWave + currentWave, maxEnemiesPerWave);

        for (int i = 0; i < enemiesThisWave; i++)
        {
            Vector3 pos = spawner.spawnPoints[Random.Range(0, spawner.spawnPoints.Length)].position;

            GameObject ghost = randomFactory.CreateEnemy(pos);

            EnemyController controller = ghost.GetComponent<EnemyController>();
            controller.moveSpeed += controller.moveSpeed * speedMultiplierPerWave * currentWave;

            yield return new WaitForSeconds(spawnInterval);
        }

        yield return new WaitForSeconds(waveInterval);
    }


    public void ChestHit(GameObject enemy, Vector3 position, ref int currentHealth)
    {
        currentHealth--;

        GameEvent hitEvent = new GameEvent("ChestHit", enemy, position);
        eventQueue.AddEvent(hitEvent);
        NotifyObservers(hitEvent);

        if (currentHealth <= 0)
        {
            GameEvent gameOverEvent = new GameEvent("GameOver", enemy, position);
            eventQueue.AddEvent(gameOverEvent);
            NotifyObservers(gameOverEvent);
        }
    }

    public void OnEnemyKilled(GameObject enemy, Vector3 position)
    {
        GameEvent scoreEvent = new GameEvent("KillEnemy", enemy, position);
        eventQueue.AddEvent(scoreEvent);
        NotifyObservers(scoreEvent);

        Destroy(enemy);
        player.ParryBoost();
    }
}
