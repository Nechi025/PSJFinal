using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interfaz generica de clonado
public interface IPrototype<T>
{
    T Clone();
}
