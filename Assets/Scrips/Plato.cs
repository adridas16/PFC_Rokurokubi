using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plato : MonoBehaviour
{
    private bool yaLavado;
    private MeshRenderer m_Renderer;
    [SerializeField] private Material limpio;
    public bool YaLavado { get => yaLavado; set => yaLavado = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LavaPlatos"))
        {
            m_Renderer.material = limpio;
        }
            
    }
}
