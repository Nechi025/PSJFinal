using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour, IObserver
{
    public Chest chest;
    public AttackZone player;
    public GameObject[] lifes;
    private int chestLifes;

    public TextMeshProUGUI points;

    private int score;

    void Start()
    {
        chest.AddObserver(this);
        player.AddObserver(this);
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
        chest.RemoveObserver(this);
        player.RemoveObserver(this);
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
