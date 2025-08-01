using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Transform target;

    void Start()
    {
        // Buscar la urna por tag o nombre
        GameObject chestObject = GameObject.FindWithTag("Chest");

        if (chestObject != null)
        {
            target = chestObject.transform;
        }
        else
        {
            Debug.LogError("No se encontró el cofre");
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }
}
