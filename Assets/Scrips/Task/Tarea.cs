using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea : MonoBehaviour
{
    [SerializeField]
    protected float tiempoExtra;

    public void Terminar()
    {
        Spawner.spawner.Timer += tiempoExtra;
    }
}
