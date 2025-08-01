using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMovementStrategy movementStrategy;

    public float moveSpeed = 2f;
    public enum StrategyType { ToUrn, ToPlayer }
    public StrategyType strategyType;
    //private Transform target;

    void Start()
    {
        switch (strategyType)
        {
            case StrategyType.ToUrn:
                movementStrategy = new MoveToChestStrategy(moveSpeed);
                break;
            case StrategyType.ToPlayer:
                movementStrategy = new MoveToPlayerStrategy(moveSpeed);
                break;
        }
    }

    void Update()
    {
        movementStrategy?.Move(transform);
    }
}
