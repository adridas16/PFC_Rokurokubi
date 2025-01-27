using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDeMisiones : MonoBehaviour
{
    [SerializeField] private InteractionSystem interactionSystem;
    [SerializeField] private RellenarElementos rellenarElementos;
    [SerializeField] private LavarPlato lavarPlato;
    [SerializeField] public  int misionesCumplidas;
    [SerializeField] private int platosLavados;
    [SerializeField] private TMP_Text misionVentana;
    [SerializeField] private TMP_Text RellenarText;
    [SerializeField] private TMP_Text misionPlatos;
    void Update()
    {
        MisionVentanas();
        MisionRellenar();
        MisionPlatos();
    }
    public void MisionVentanas()
    {
         if (interactionSystem.ventanas >= 2)
        {
            misionVentana.text = "VentanasCerradas";
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
        }
    }
    private void LLave()
    {

    }
}
