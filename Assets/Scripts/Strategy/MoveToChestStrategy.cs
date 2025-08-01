using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToChestStrategy : IMovementStrategy
{
    private Transform chest;
    private float speed;

    public MoveToChestStrategy(float speed)
    {
        this.speed = speed;
        chest = GameObject.FindWithTag("Chest").transform;
    }

    public void Move(Transform self)
    {
        if (chest == null) return;
        Vector2 direction = (chest.position - self.position).normalized;
        self.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
