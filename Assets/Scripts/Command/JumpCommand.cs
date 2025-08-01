using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private PlayerController player;
    public JumpCommand(PlayerController player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Jump();
    }
}
