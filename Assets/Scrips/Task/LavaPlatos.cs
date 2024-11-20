using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LavarPlato : MonoBehaviour
{
     
    [SerializeField] TMP_Text misionCumplidaText;
    [SerializeField] int platosLavados;
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
                platosLavados++;
                if (platosLavados >= 5)
                {
                    misionCumplidaText.text = "MisionCumplida";
                }
                other.gameObject.GetComponent<Plato>().YaLavado = true;

            }
            
            
            
        }
    }
}
