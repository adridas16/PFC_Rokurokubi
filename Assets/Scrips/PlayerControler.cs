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
    [SerializeField] private GameObject pause;
    [SerializeField] private GameObject canvasplayer;
    private void Start()
    {
        controller =GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        anim = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Time.timeScale > 0) 
        {
            MovimientoyCam();
            Agacharte();
            
        }
      Pause();
    }

    private void MovimientoyCam()
    {
     
        groundedPlayer = controller.isGrounded;
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
    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            pause.SetActive(true);
            canvasplayer.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        
    }
}
