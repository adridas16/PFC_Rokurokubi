using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LavarPlato : MonoBehaviour
{


    [SerializeField] SistemaDeMisiones sistemaDeMisiones;

   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
