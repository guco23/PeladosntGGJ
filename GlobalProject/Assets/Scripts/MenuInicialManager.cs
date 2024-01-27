using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInicialManager : MonoBehaviour
{
    public GameObject playerContainer;
    public GameObject player;
    public GameObject contenedorUI;

    public float DistanceToMove = 9;
    public float velocity = 5;
    public float initalPosZ = 2;

    int state;

    private void Start()
    {
        state =0;
        SetPlayerComponents(false);
        initalPosZ = playerContainer.transform.position.z;
    }


    void SetPlayerComponents(bool On)
    {
        player.GetComponent<PlayerInput>().enabled =    On;
        player.GetComponent<PlayerMovementAPH>().enabled = On;
        player.GetComponent<CharacterController>().enabled = On;
        player.GetComponent<Rigidbody>().useGravity = On;
        player.GetComponent<PlayerManager>().enabled = On;
        player.GetComponent<PlayerRaycast>().enabled = On;
        player.GetComponent<PlayerPlaceComponent>().enabled = On;

        //player.GetComponent<PlayerInput>().currentActionMap.Disable();

    }


    private void Update()
    {
        if(state == 1)
        {
            print(initalPosZ + DistanceToMove);
            if (playerContainer.transform.position.z < initalPosZ + DistanceToMove)
                playerContainer.transform.position = new Vector3(
                    playerContainer.transform.position.x,
                    playerContainer.transform.position.y,
                    playerContainer.transform.position.z + (velocity * Time.deltaTime));

        }
    }

    public void NextState()
    {
        contenedorUI.SetActive(false);
        state++;
    }
}

