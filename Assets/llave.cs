using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    Camera cam;
    private llave lave;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private GameObject PanelV;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
               
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHitOBJ, pickUpDistance))
                {

                    if (raycastHitOBJ.transform.TryGetComponent(out lave))
                    {
                       Time.timeScale = 0;
                       PanelV.SetActive(true);
                       Cursor.lockState = CursorLockMode.None;
                    }



                }

            }
        }
}
