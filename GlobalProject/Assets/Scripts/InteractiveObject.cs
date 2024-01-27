using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    private string objectName;

    [SerializeField]
    [Tooltip("Malla a la que se le aplica el reborde")]
    private MeshRenderer borderMesh;
  
    public string getName() { return objectName; }
    private void Start()
    {

    }

    public void SetColor(bool selected) {

        if (borderMesh == null) return;
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

