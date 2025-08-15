using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueueManager : MonoBehaviour
{
    private Queue<GameEvent> eventQueue = new Queue<GameEvent>();

    void Update()
    {
        int eventsToProcess = eventQueue.Count;
        for (int i = 0; i < eventsToProcess; i++)
        {
            GameEvent gameEvent = eventQueue.Dequeue();
            HandleEvent(gameEvent);
        }
    }

    public void AddEvent(GameEvent gameEvent)
    {
        eventQueue.Enqueue(gameEvent);
    }

    private void HandleEvent(GameEvent gameEvent)
    {
        switch (gameEvent.eventType)
        {
            case "ChestHit":
                Debug.Log("La lampara fue golpeada");
                break;
            case "GameOver":
                Debug.Log("Game Over!");
                break;
        }
    }
}
