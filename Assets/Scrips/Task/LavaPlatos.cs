using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LavarPlato : MonoBehaviour
{
    [SerializeField] SistemaDeMisiones sistemaDeMisiones;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Plato"))
        {
            if(!other.gameObject.GetComponent<Plato>().YaLavado)
            {
                sistemaDeMisiones.MisionPlatosC();
                other.gameObject.GetComponent<Plato>().YaLavado = true;

            }
            
            
            
        }
    }
 
   
}
