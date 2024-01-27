using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private string objectName;

    [SerializeField]
    private MeshRenderer borderMesh;
  
    public string getName() { return objectName; }
    private void Start()
    {

    }

    public void SetColor(bool selected) { 
        if(selected)
        {
            borderMesh.material.color = Color.yellow;
        }
        else
        {
            borderMesh.material.color = Color.black;
        }
    }
}

