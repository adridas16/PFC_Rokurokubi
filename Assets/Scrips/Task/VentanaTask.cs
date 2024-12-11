using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentanaTask : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float tiempoAbrir;
    bool VentanaCerrada=false;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        tiempoAbrir = Random.Range(0f, 15f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("cierra");
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                Debug.Log("cierracals");
                anim.SetBool("Abrir", true);
                VentanaCerrada = true;
            }

        }
    }
    private void Temporizador()
    {
        if (VentanaCerrada==false)
        {
            tiempoAbrir+=Time.deltaTime;

            if (tiempoAbrir >= 20)
            {
                anim.SetBool("Abrir", false);
                Debug.Log("abre");
            }
        }
       
        
       

    }
}
