using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour, IObserver
{
    public Chest chest;

    void Start()
    {
        chest.AddObserver(this);
    }

    public void OnNotify(GameEvent gameEvent)
    {
        if (gameEvent.eventType == "GameOver")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnDestroy()
    {
        chest.RemoveObserver(this);
    }
}
