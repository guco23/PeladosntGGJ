using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementAPH : MonoBehaviour
{

    #region parameters


    [SerializeField] private float speed;


    #endregion


    #region references




    #endregion


    #region properties


    private CharacterController controller;

    private Vector2 myDir;

    private int dirX = 0;

    private int dirY = 0;

    private Camera mainCamera;


    #endregion



    public void DirMovement(InputAction.CallbackContext context)
    {

        myDir = context.ReadValue<Vector2>();

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

        Vector3 move = myDir.y * mainCamera.transform.forward + myDir.x * mainCamera.transform.right; 

        Debug.Log(move);

        controller.Move(move * Time.deltaTime * speed);
        
    }
}
