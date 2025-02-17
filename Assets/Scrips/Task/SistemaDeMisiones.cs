using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDeMisiones : Tarea
{
    [SerializeField] private InteractionSystem interactionSystem;
    [SerializeField] private RellenarElementos rellenarElementos;
    [SerializeField] private LavarPlato lavarPlato;
    [SerializeField] public  int misionesCumplidas;
    [SerializeField] private int platosLavados;
    [SerializeField] private TMP_Text misionVentana;
    [SerializeField] private TMP_Text RellenarText;
    [SerializeField] private TMP_Text misionPlatos;
    private bool misionVterminada=false;
    private bool misionRterminada=false;
    private bool misionPterminada=false;
    public int finalJuego;
    [SerializeField] GameObject llave;
    Camera cam;
    private int pickUpDistance;
    
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
            finalJuego++;
            if (!misionVterminada) 
            {
                Terminar();
                misionVterminada = true;
                

            }
           
         }
    }
    public void MisionRellenarC()
    {
        misionesCumplidas++;
        Debug.Log(misionesCumplidas);
    }
    private void MisionRellenar()
    {
        if (misionesCumplidas >= 3)
        {
            RellenarText.text = "Objetos Rellenados";
            if(!misionRterminada)
            {
                Terminar();
                misionRterminada = true;
                finalJuego++;
            }
            
        }
    }
    public void MisionPlatosC()
    {
        platosLavados++;
        Debug.Log(platosLavados);
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
    private void LLave()
    {
        if(finalJuego >= 3)
        {
            llave.gameObject.SetActive(true);
        }
       
    }
}
