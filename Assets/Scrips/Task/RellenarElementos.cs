using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RellenarElementos : MonoBehaviour
{
    [SerializeField] private TMP_Text RellenarText;
    private static int misionCumplida;
    [SerializeField] Material m_Vacio; 
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
                    
                    misionCumplida++;
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
                   
                    misionCumplida++;
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
                    
                    misionCumplida++;
                    collision.gameObject.GetComponent<Rellenados>().yaHarina = true;

                }



            }
        }
            
    }
   private void MisionCumplidaTexto()
   {
      if (misionCumplida >= 3)
      {
       RellenarText.text = "Objetos Rellenados";
      }
   }
    
}
