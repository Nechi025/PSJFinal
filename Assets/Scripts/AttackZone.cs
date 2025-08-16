using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour, ISubject
{
    private PlayerController player;

    private List<IObserver> observers = new List<IObserver>();

    public EventQueueManager eventQueue;
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameEvent scoreEvent = new GameEvent("KillEnemy", other.gameObject, transform.position);
            eventQueue.AddEvent(scoreEvent);

            NotifyObservers(scoreEvent);

            Destroy(other.gameObject);
            player.ParryBoost();
        }
    }
}
