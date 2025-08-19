using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Llamo al Facade con la logica de puntaje
            GameFacade.Instance.OnEnemyKilled(other.gameObject, transform.position);
        }
    }
}
