using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : MonoBehaviour, IPrototype<GameObject>
{
    public GameObject Clone()
    {
        GameObject clone = Instantiate(this.gameObject);
        return clone;
    }
}
