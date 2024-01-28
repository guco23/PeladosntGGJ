using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Collections.Specialized.BitVector32;

public class PlayerMovementAPH : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private float crouchHeight = 1f;

    #endregion


    #region references



    #endregion


    #region properties


    private CharacterController controller;

    private Vector2 myDir;

    private Camera mainCamera;

    private float actualVelocity;

    private Vector3 move;

    private float standingHeight;

    private float actualHeight;

    #endregion


    private void ApplyGravity()
    {

        move.y = actualVelocity;

        if (controller.isGrounded && move.y < 0)
        {

            actualVelocity = -1;

        }
        else
        {
            actualVelocity -= gravity * Time.deltaTime;
        }

       
    }

    public void DirMovement(InputAction.CallbackContext context)
    {

        myDir = context.ReadValue<Vector2>();

    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (controller.isGrounded && context.started)
        {

            actualVelocity = jumpForce;

        }


    }

    public void Crouch(InputAction.CallbackContext context)
    {
        Debug.Log("Crouch");

        if (context.action.triggered && context.action.ReadValue<float>() > 0)
        {
            Debug.Log("Down");
            actualHeight = crouchHeight;

        }
        else
        {
            Debug.Log("Up");

            actualHeight = standingHeight;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();

        mainCamera = Camera.main;

        standingHeight = controller.height;
        actualHeight = standingHeight;

    }

    // Update is called once per frame
    void Update()
    {
        move = (myDir.y * mainCamera.transform.forward + myDir.x * mainCamera.transform.right) * speed;

        ApplyGravity();

        controller.Move(move * Time.deltaTime);

        controller.height = actualHeight;
        

    }
}
