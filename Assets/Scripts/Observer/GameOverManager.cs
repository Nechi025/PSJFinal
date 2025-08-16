using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour, IObserver
{
    public GameFacade facade;
    public GameObject gameOverScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        facade.AddObserver(this);
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
        facade.RemoveObserver(this);
    }

    public void GoToMenu()
    {

    }
}
