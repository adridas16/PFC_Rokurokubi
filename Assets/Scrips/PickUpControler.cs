using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpControler : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float pickUpDistance = 2f;
            Physics.Raycast(playerCameraTransform.position,playerCameraTransform.forward,out RaycastHit raycastHit, pickUpDistance);
        }
    }
}
