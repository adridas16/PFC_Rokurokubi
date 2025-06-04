using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ventana : Tarea
{
    [SerializeField] private Animator anim;
    [SerializeField] private float timer;
    Camera cam;
    private bool ventanaCerrada = true;
    public bool VentanaCerrada { get => ventanaCerrada; set => ventanaCerrada = value; }

    void Start()
    {
        timer = Random.Range(0f, 15f);
        cam = Camera.main;
    }

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
                VentanaCerrada = false;
            }
        }
    }

    public void Cerrar()
    {
        anim.SetBool("Abrir", false);
    }
}
