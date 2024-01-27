using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerComponent : MonoBehaviour
{
    
     //El obstacle component del padre
     
    ObstacleComponent obstacleComponent;

    [SerializeField] bool isMiddle;
    [Tooltip("Identifica si el trigger es el del medio")]

    private void Start()
    {
        obstacleComponent = transform.parent.gameObject.GetComponent<ObstacleComponent>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Aquí estoy detectando el componente PlayerPlace meh
        PlayerPlaceComponent playerPlaceComponent = other.GetComponent<PlayerPlaceComponent>();
        if (playerPlaceComponent != null)
        {
            obstacleComponent.notifyEnter(isMiddle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerPlaceComponent playerPlaceComponent = other.GetComponent<PlayerPlaceComponent>();
        if (playerPlaceComponent != null)
        {
            obstacleComponent.notifyExit(isMiddle);

        }
    }
}
