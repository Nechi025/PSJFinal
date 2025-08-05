using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMovementStrategy movementStrategy;

    public float moveSpeed = 2f;
    public enum StrategyType { ToChest, ToPlayer, ZigZagToChest }
    public StrategyType strategyType;
    //private Transform target;

    void Start()
    {
        switch (strategyType)
        {
            case StrategyType.ToChest:
                movementStrategy = new MoveToChestStrategy(moveSpeed);
                break;
            case StrategyType.ToPlayer:
                movementStrategy = new MoveToPlayerStrategy(moveSpeed);
                break;
            case StrategyType.ZigZagToChest:
                movementStrategy = new ZigZagToChestStrategy(moveSpeed);
                break;
        }
    }

    void Update()
    {
        movementStrategy?.Move(transform);
    }
}
