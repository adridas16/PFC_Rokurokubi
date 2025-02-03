using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarea : MonoBehaviour
{
    [SerializeField] protected float tiempoExtra = 50;
    [SerializeField] Spawner spawner;
    public void Terminar()
    {
        spawner.Timer += tiempoExtra;
    }
}
