using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour, IObserver
{
    public GameObject[] lifes;
    private int chestLifes;

    public TextMeshProUGUI points;

    private int score;

    void Start()
    {
        GameFacade.Instance.AddObserver(this);
        chestLifes = 3;
    }

    public void OnNotify(GameEvent gameEvent)
    {
        if (gameEvent.eventType == "ChestHit")
        {
            chestLifes--;
            LoseLife(chestLifes);
        }

        if (gameEvent.eventType == "KillEnemy")
        {
            score += 5;
            UpdateScore();
        }
    }

    void OnDestroy()
    {
        GameFacade.Instance.RemoveObserver(this);
    }

    public void LoseLife(int index)
    {
        lifes[index].SetActive(false);
    }

    public void UpdateScore()
    {
        points.text = score.ToString();
    }
}
