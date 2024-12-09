using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rellenados : MonoBehaviour
{

     MeshRenderer m_RendererAzucar;
     MeshRenderer m_RendererCafe;
     MeshRenderer m_RendererHarina;
    [SerializeField] private Material m_Cafe;
    [SerializeField] private Material m_Azucar;
    [SerializeField] private Material m_Harina;
    
    bool YaAzucar =false;
    bool YaCafe =false;
    bool YaHarina =false;

    public bool yaHarina { get => YaHarina; set => YaHarina = value; }
    public bool yaCafe { get => YaCafe; set => YaCafe = value; }
    public bool yaAzucar { get => YaAzucar; set => YaAzucar = value; }


    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("RellenarAzucar"))
        {
            m_RendererAzucar = GetComponent<MeshRenderer>();
          
        }
        if (CompareTag("RellenarCafe"))
        {
            m_RendererCafe = GetComponent<MeshRenderer>();
            
        }
        if (CompareTag("RellenarHarina"))
        {
            m_RendererHarina = GetComponent<MeshRenderer>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RellenableHarina"))
        {
            m_RendererHarina.material = m_Harina;
        }
        if (collision.gameObject.CompareTag("RellenableAzucar"))
        {
            m_RendererAzucar.material = m_Azucar;
        }
        if (collision.gameObject.CompareTag("RellenableCafe"))
        {
            m_RendererCafe.material = m_Cafe;
        }

    }

}
