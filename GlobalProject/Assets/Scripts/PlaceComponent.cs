using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CooldownComponent))]
public class PlaceComponent : MonoBehaviour
{
    [SerializeField]
    [Tooltip("El tag indicador del place")]
    string placeTag;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPlaceComponent playerPlaceComponent = other.GetComponent<PlayerPlaceComponent>();
        if(playerPlaceComponent != null)
        {
            playerPlaceComponent.enteredPlace(this.placeTag,this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerPlaceComponent playerPlaceComponent = other.GetComponent<PlayerPlaceComponent>();
        if (playerPlaceComponent != null)
        {
            playerPlaceComponent.exitedPlace();
        }
    }
}
