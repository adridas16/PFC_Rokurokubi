using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControler : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    private Animator anim;
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
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnGUI()
    {        if(GUI.Button(new Rect(0,0,100,50),"Lock Cursor"))
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("Agacharse", true);
            Debug.Log("agachado");
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("Agacharse", false);
        }
    }

}
