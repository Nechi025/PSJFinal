using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.A)) direction += Vector2.left;
        if (Input.GetKey(KeyCode.D)) direction += Vector2.right;

        // Ejecutar movimiento solo si se está presionando una tecla
        ICommand moveCommand = new MoveCommand(player, direction);
        moveCommand.Execute();

        // Ejecutar salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ICommand jumpCommand = new JumpCommand(player);
            jumpCommand.Execute();
        }
    }

}
