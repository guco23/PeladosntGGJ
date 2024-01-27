using Palmmedia.ReportGenerator.Core.Parser.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementAPH : MonoBehaviour
{

    #region parameters

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    #endregion


    #region references



    #endregion


    #region properties


    private CharacterController controller;

    private Vector2 myDir;

    private Camera mainCamera;

    private float actualVelocity;

    private Vector3 move;



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
        Debug.Log(controller.isGrounded);

        if (controller.isGrounded && context.started)
        {

            actualVelocity = jumpForce;

        }


    }


    // Start is called before the first frame update
    void Start()
    {
        
        controller = GetComponent<CharacterController>();

        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        move = (myDir.y * mainCamera.transform.forward + myDir.x * mainCamera.transform.right) * speed;

        ApplyGravity();

        controller.Move(move * Time.deltaTime);

        

        

    }
}
