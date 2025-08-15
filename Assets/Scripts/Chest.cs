using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    private int maxHealth = 3;
    private int currentHealth;

    public EventQueueManager eventQueue;

    void Start()
    {
        currentHealth = maxHealth;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHealth--;

            GameEvent hitEvent = new GameEvent("ChestHit", collision.gameObject, transform.position);
            eventQueue.AddEvent(hitEvent);

            NotifyObservers(hitEvent);

            if (currentHealth <= 0)
            {
                GameEvent gameOverEvent = new GameEvent("GameOver", collision.gameObject, transform.position);
                eventQueue.AddEvent(gameOverEvent);
                NotifyObservers(gameOverEvent);
            }
        }
    }
}
