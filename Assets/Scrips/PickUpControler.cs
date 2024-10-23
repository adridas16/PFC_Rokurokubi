using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpControler : MonoBehaviour
{
    [SerializeField] private float PickUpForce = 150f;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPointTransform;
    private ObjectGrabable ObjectGrabable;
    [SerializeField] Rigidbody objectRigibody;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ObjectGrabable == null)
            {
                //sin coger objeto se intenta agarrar
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {

                    if (raycastHit.transform.TryGetComponent(out ObjectGrabable))
                    {
                        ObjectGrabable.Grab(objectGrabPointTransform);
                        Debug.Log(ObjectGrabable);
                    }

                } 
            }
            else
            {
                //agarrando algo
                ObjectGrabable.Drop();
                ObjectGrabable=null;

            }

        }
    }

    private void FixedUpdate()
    {
        if (ObjectGrabable != null)
        {
           MoveObject();
        }
        
    }

    public void MoveObject()
    {
        if (Vector3.Distance(objectRigibody.transform.position, objectGrabPointTransform.position) > 0.1f)
        {
            Debug.Log("añado fuerxa");
            Vector3 moveDirection = (objectGrabPointTransform.position - ObjectGrabable.transform.position).normalized;
            objectRigibody.AddForce(moveDirection * moveDirection.magnitude * PickUpForce, ForceMode.Force);

        }
        else
        {
            Debug.Log("Cancelar fuerza");
            objectRigibody.velocity = Vector3.zero;
        }
    }

}

