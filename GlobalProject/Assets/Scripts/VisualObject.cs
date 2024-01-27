using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CooldownComponent))]
public class VisualObject : MonoBehaviour
{
    [SerializeField]
    private string objectName;

    public string getName() { return objectName; }
    
}

