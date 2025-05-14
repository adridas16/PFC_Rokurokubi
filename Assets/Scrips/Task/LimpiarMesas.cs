using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class LimpiarMesas : MonoBehaviour
{
    [SerializeField] SistemaDeMisiones sistemadeMisiones;
    [SerializeField] private int nPapeles=0;

    void Start()
    {
        
    }

    void Update()
    {
        MisionPapelera();   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Papeles"))
        {
            nPapeles++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Papeles"))
        {
            if (nPapeles >= 3)
            {
                sistemadeMisiones.finalJuego--;
                sistemadeMisiones.misionLterminada = false;
                nPapeles--;
            }
            else if (nPapeles < 3)
            {
                nPapeles--;
            }
            
        }
    }
    private void MisionPapelera()
    {
        if (nPapeles >= 3)
        {
            Debug.Log("mesas limpias");
            sistemadeMisiones.MisionLimpiarMesas();
        }
    }


}
