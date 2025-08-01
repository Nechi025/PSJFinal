using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private PlayerController player;
    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            player.ParryBoost();
        }
    }
}
