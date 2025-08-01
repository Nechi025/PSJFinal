using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerStrategy : IMovementStrategy
{
    private Transform player;
    private float speed;

    public MoveToPlayerStrategy(float speed)
    {
        this.speed = speed;
        player = GameObject.FindWithTag("Player").transform;
    }

    public void Move(Transform self)
    {
        if (player == null) return;
        Vector2 direction = (player.position - self.position).normalized;
        self.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
