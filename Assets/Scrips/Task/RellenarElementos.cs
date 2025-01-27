using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RellenarElementos : MonoBehaviour
{
    
    [SerializeField] Material m_Vacio;
    [SerializeField] SistemaDeMisiones sistemaDeMisiones;
    MeshRenderer m_RendererRellenarAzucar;
    MeshRenderer m_RendererRellenarCafe;
    MeshRenderer m_RendererRellenarHarina;

 


    // Start is called before the first frame update
    void Start()
    {
       
        if (CompareTag("RellenableCafe"))
        {
            m_RendererRellenarCafe= GetComponent<MeshRenderer>();
        }
        if (CompareTag("RellenableAzucar"))
        {
            m_RendererRellenarAzucar= GetComponent<MeshRenderer>();
        }
        if (CompareTag("RellenableHarina"))
        {
            m_RendererRellenarHarina= GetComponent<MeshRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MisionCumplidaTexto();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (CompareTag("RellenableCafe"))
        {
           
            if (collision.gameObject.CompareTag("RellenarCafe"))
            {
             
                m_RendererRellenarCafe.material = m_Vacio;
                if (!collision.gameObject.GetComponent<Rellenados>().yaCafe)
                {
                    //AVISAR A EVENTMANAGER de misionCumplida++ 
                    //SistemaMisiones.instance.misionCumplida++;
                    sistemaDeMisiones.MisionRellenarC();
                    collision.gameObject.GetComponent<Rellenados>().yaCafe = true;
                    
                }



            }
        }
        if (CompareTag("RellenableAzucar"))
        {
            if (collision.gameObject.CompareTag("RellenarAzucar"))
            {
                m_RendererRellenarAzucar.material = m_Vacio;
                if (!collision.gameObject.GetComponent<Rellenados>().yaAzucar)
                {

                    sistemaDeMisiones.MisionRellenarC();
                    collision.gameObject.GetComponent<Rellenados>().yaAzucar = true;

                }



            }
        }
            
        if (CompareTag("RellenableHarina"))
        {
            if (collision.gameObject.CompareTag("RellenarHarina"))
            {
                m_RendererRellenarHarina.material = m_Vacio;
                if (!collision.gameObject.GetComponent<Rellenados>().yaHarina)
                {

                    sistemaDeMisiones.MisionRellenarC();
                    
                    collision.gameObject.GetComponent<Rellenados>().yaHarina = true;

                }



            }
        }
            
    }
   private void MisionCumplidaTexto()
   {
      
   }
    
}
