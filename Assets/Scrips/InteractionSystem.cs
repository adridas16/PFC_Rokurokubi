using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float interactionDistance;
    [SerializeField] private TMP_Text textoMisionCumplida;

    private int ventanas;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, interactionDistance))
            {
                if(hitinfo.transform.TryGetComponent(out Ventana ventana))
                {
                    if(!ventana.VentanaCerrada)
                    {
                        ventana.Cerrar();
                        ventanas++;
                        VentanasCerradas();

                    }

                }
                
                
            }

        }
    }

    private void VentanasCerradas()
    {
        if (ventanas >= 2)
        {
            textoMisionCumplida.text = "VentanasCerradas";
        }
    }
}
