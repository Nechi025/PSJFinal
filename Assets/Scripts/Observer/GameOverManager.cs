using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour, IObserver
{
    public GameObject gameOverScreen;

    void Start()
    {
        gameOverScreen.SetActive(false);
        GameFacade.Instance.AddObserver(this);
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
        GameFacade.Instance.RemoveObserver(this);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
