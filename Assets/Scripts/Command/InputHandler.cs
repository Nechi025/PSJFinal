using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;

    private Queue<ICommand> commandQueue = new Queue<ICommand>();
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        direction = direction.normalized;
        commandQueue.Enqueue(new MoveCommand(player, direction));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            commandQueue.Enqueue(new JumpCommand(player));
        }

        if (Input.GetMouseButtonDown(0))
        {
            commandQueue.Enqueue(new AttackCommand(player));
        }

        // Ejecutar todos los comandos encolados
        while (commandQueue.Count > 0)
        {
            commandQueue.Dequeue().Execute();
        }
    }

}
