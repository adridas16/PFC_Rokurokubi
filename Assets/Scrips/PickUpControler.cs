using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpControler : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position,playerCameraTransform.forward,out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask)) 
            {
               
                if(raycastHit.transform.TryGetComponent(out ObjectGrabable objectGrabable))
                {       
                    objectGrabable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabable);
                }

            }
        }
    }
}
