using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class Ventana : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float timer;
    private int ventanas;
    Camera cam;
    private float distanciaVentana=2;
    private bool ventanaCerrada = true;
    public bool VentanaCerrada { get => ventanaCerrada; set => ventanaCerrada = value; }

    void Start()
    {
        timer = Random.Range(0f, 15f);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
    }
    private void Temporizador()
    {
        if (ventanaCerrada)
        {
            timer += Time.deltaTime;

            if (timer >= 20)
            {
                anim.SetBool("Abrir", true);
                Debug.Log("abre");
                VentanaCerrada = false;
            }
        }
       
        
       

    }

    public void Cerrar()
    {
        anim.SetBool("Abrir", false);


    }
}
