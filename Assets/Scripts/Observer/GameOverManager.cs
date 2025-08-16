using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour, IObserver
{
    public Chest chest;
    public GameObject gameOverScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        chest.AddObserver(this);
    }

    public void OnNotify(GameEvent gameEvent)
    {
        if (gameEvent.eventType == "GameOver")
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnDestroy()
    {
        chest.RemoveObserver(this);
    }

    public void GoToMenu()
    {

    }
}
