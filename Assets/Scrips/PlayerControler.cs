using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControler : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    private Animator anim;
    private bool isAgachado = false;
    Vector3 movementDirection;
    Vector2 movement;
    private void Start()
    {
        controller =GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        MovimientoyCam();
        CursorBlock();
        Agacharte();
    }

    private void MovimientoyCam()
    {
     
        groundedPlayer = controller.isGrounded;
        Debug.Log(groundedPlayer);
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        movement = inputManager.GetPlayerMovement();
        movementDirection = new Vector3(movement.x, 0f, movement.y);
        movementDirection = cameraTransform.forward * movementDirection.z + cameraTransform.right * movementDirection.x;
        movementDirection.y = 0f;
        controller.Move(movementDirection  * playerSpeed * Time.deltaTime);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer&& !isAgachado)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnGUI()
    {   
        if(GUI.Button(new Rect(0,0,100,50),"Lock Cursor"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        if(GUI.Button(new Rect(125,0,100,50),"Confine Cursor"))
        {
            Cursor.lockState= CursorLockMode.Confined;
        }
    }

    private void CursorBlock()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState=CursorLockMode.None;
        }
    }
    private void Agacharte()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && groundedPlayer && !isAgachado)
        {
            
            anim.SetBool("Agacharse", true);
            Debug.Log("agachado");
            playerSpeed = 1.5f;
            isAgachado = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && groundedPlayer && isAgachado)
        {
                
            anim.SetBool("Agacharse", false);
            Debug.Log("NO agachado");
            isAgachado = false;

        }
    }
    public void VelAgacharse()
    {
        
        playerSpeed = 4f;
    }
}
