using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private PlayerController player;

    public AttackCommand(PlayerController player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Parry();
    }
}
