using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpControler : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    private ObjectGrabable ObjectGrabable;
    private Camera cam;
    [SerializeField] private float DistacioaInteraccion;
    private Transform interactuableActual;
    private float pickUpDistanceOutline = 2.5f;




    private void Update()   
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectGrabable == null)
            {
                //sin coger objeto se intenta agarrar
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitOBJ, pickUpDistance, pickUpLayerMask))
                {

                    if (raycastHitOBJ.transform.TryGetComponent(out ObjectGrabable))
                    {
                        ObjectGrabable.Grab(objectGrabPointTransform);
                        


                        


                    }
                    


                }
                
            }
            else
            {
                //agarrando algo
                ObjectGrabable.Drop();
                ObjectGrabable = null;

            }


        }


        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistanceOutline, pickUpLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out Outline outlineColor))
            {
                interactuableActual = raycastHit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
            }
            else if (interactuableActual)
            {
                interactuableActual.GetComponent<Outline>().enabled = false;
                interactuableActual = null;
            }
        }
           

    }
    private void FixedUpdate()
    {
        if (ObjectGrabable != null)
        {
            ObjectGrabable.MoveObject();
        }
    }

} 

