using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour, IObserver
{
    public Chest chest;
    public GameObject[] lifes;
    private int maxLifes;
    private int currentLifes;

    void Start()
    {
        chest.AddObserver(this);
        maxLifes = 3;
        currentLifes = maxLifes;
    }

    public void OnNotify(GameEvent gameEvent)
    {
        if (gameEvent.eventType == "ChestHit")
        {
            currentLifes--;
            LoseLife(currentLifes);
        }
    }

    void OnDestroy()
    {
        chest.RemoveObserver(this);
    }

    public void LoseLife(int index)
    {
        lifes[index].SetActive(false);
    }
}
