using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    
    private llave lave;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private GameObject PanelV;
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float pickUpDistance = 2f;
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitOBJ, pickUpDistance))
            {

                if (raycastHitOBJ.transform.TryGetComponent(out lave))
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    PanelV.SetActive(true);
                    
                }
            }
        }
    }
}
