using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApagarLuces : Tarea
{
    [SerializeField] List<GameObject> listaLuces;
    [SerializeField]float timerLuz=0;
    [SerializeField] Animator anim;
    int luces;
    Camera cam;
    [SerializeField] private float distancialuz;
    private bool seApaga=false;
    private bool misionTerminada=false;
    SistemaDeMisiones sistemaDeMisiones;
    void Start()
    {
       cam=Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        timerLuz += Time.deltaTime;
        ApagarLuz();
        EncenderLuz();
    }
    void ApagarLuz()
    {
        if (timerLuz >= 30&&luces==0)
        {
            
            for (int i = 0; i < listaLuces.Count; i++)
            {
              listaLuces[i].gameObject.SetActive(false);
              anim.SetBool("Apagon", true);
              seApaga = true;
            }
            
            
        }
        else if (luces >= 1)
        {
            for (int i = 0; i < listaLuces.Count; i++)
            {
                listaLuces[i].gameObject.SetActive(true);
                anim.SetBool("Apagon", false);
            }
        }
       
    }
   

    void EncenderLuz()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, distancialuz)&& seApaga)
        {
            if (hitinfo.transform.CompareTag("ApagarLuz"))
            {
                hitinfo.transform.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E)&& !misionTerminada)
                {
                    
                    
                    luces++;
                   
                    Terminar();
                    misionTerminada = true;
                    sistemaDeMisiones.finalJuego++;
                    
                    
                }

            }
            else if (!hitinfo.transform.CompareTag("ApagarLuz"))
            {
                hitinfo.transform.GetComponent<Outline>().enabled = false;
            }

        }
    }
}
