using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class SistemaDeMisiones : Tarea
{
    [SerializeField] private InteractionSystem interactionSystem;
    [SerializeField] private RellenarElementos rellenarElementos;
    [SerializeField] private LavarPlato lavarPlato;
    [SerializeField] public  int misionesCumplidas;
    [SerializeField] private int platosLavados;
    [SerializeField] private TMP_Text misionVentana;
    [SerializeField] private TMP_Text misionRellenar;
    [SerializeField] private TMP_Text misionPlatos;
    [SerializeField]private bool misionVterminada=false;
    [SerializeField] private bool misionRterminada=false;
    [SerializeField] private bool misionPterminada=false;
    public bool misionLterminada=false;
    public int finalJuego;
    [SerializeField] GameObject llave;
    Camera cam;

    private void Start()
    {
        cam=Camera.main;
    }

    void Update()
    {
        MisionVentanas();
        MisionRellenar();
        MisionPlatos();
        LLave();
    }
    public void MisionVentanas()
    {
         if (interactionSystem.ventanas >= 2)
         {
            misionVentana.text = "VentanasCerradas";
            
            if (!misionVterminada) 
            {
                Terminar();
                misionVterminada = true;
                finalJuego++;

            }
           
         }
    }
    public void MisionRellenarC()
    {
        misionesCumplidas++;
    }
    private void MisionRellenar()
    {
        if (misionesCumplidas >= 3 && !misionRterminada)
        {
                Terminar();
                misionRterminada = true;
                finalJuego++;
            
            
        }
    }
    public void MisionPlatosC()
    {
        platosLavados++;
    }
    private void MisionPlatos()
    {
        if (platosLavados >= 5)
        {
            misionPlatos.text = "Platos Lavados";
            if(!misionPterminada)
            {
                Terminar();
                misionPterminada = true;
                finalJuego++;
            }
            
            
        }
    }
    public void MisionLimpiarMesas()
    {
       
            if (!misionLterminada)
            {
                Terminar();
                misionLterminada = true;
                finalJuego++;
            }

        
    }
    private void LLave()
    {
        if(finalJuego >= 4)
        {
            llave.gameObject.SetActive(true);
        }
       
    }
}
