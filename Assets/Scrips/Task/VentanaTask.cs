using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VentanaTask : MonoBehaviour
{
    Animator anim;
    [SerializeField] private float tiempoAbrir;
    bool VentanaCerrada=false;
    private int ventanas;
    [SerializeField] private TMP_Text misionCumplidaText;
    Camera cam;
    private float distanciaVentana=2;

    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        tiempoAbrir = Random.Range(0f, 15f);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
        VentanasCerradas();
        //VentanaAbrir();
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
                ventanas++;


            }

        }
    }
    private void Temporizador()
    {
        if (!VentanaCerrada)
        {
            tiempoAbrir+=Time.deltaTime;

            if (tiempoAbrir >= 20)
            {
                anim.SetBool("Abrir", false);
                Debug.Log("abre");
                VentanaCerrada = true;
            }
        }
       
        
       

    }
    private void VentanasCerradas()
    {
        if (ventanas >= 2)
        {
            misionCumplidaText.text = "VentanasCerradas";
        }
    }
    //private void VentanaAbrir()
    //{
    //    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, distanciaVentana) && VentanaCerrada)
    //    {
    //        Debug.DrawRay(cam.transform.position, cam.transform.position + cam.transform.forward * distanciaVentana, Color.red, 5);
    //        if (hitinfo.transform.CompareTag("CerrarVentana"))
    //        {
    //            if (Input.GetKeyDown(KeyCode.E))
    //            {
    //                Debug.Log(hitinfo);
    //                anim.SetBool("Abrir", true);
    //                ventanas++;
    //            }
    //        }
    //    }
    //}
}
