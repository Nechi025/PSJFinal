using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private IMovementStrategy movementStrategy;
    private EnemyData enemyData;

    public SpriteRenderer spriteRenderer;
    public float moveSpeed;

    public enum StrategyType { ToChest, ToPlayer, ZigZagToChest }
    public StrategyType strategyType;

    void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(EnemyData data)
    {
        enemyData = data;
        moveSpeed = data.baseSpeed;

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = data.sprite;
        }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            Destroy(this.gameObject);
        }
    }
}
