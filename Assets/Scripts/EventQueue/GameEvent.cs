using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent
{
    public string eventType;
    public GameObject target;
    public Vector3 position;

    public GameEvent(string type, GameObject target = null, Vector3 position = default)
    {
        eventType = type;
        this.target = target;
        this.position = position;
    }
}
