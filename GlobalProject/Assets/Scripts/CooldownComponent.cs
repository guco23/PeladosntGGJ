using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownComponent : MonoBehaviour
{
    [SerializeField]
    private float cooldownTime = 3;

    private float currentTime;

    bool IsTime = true;

    private void Start()
    {
        currentTime = cooldownTime;
    }

    private void Update()
    {
        if (!IsTime)
        {
            currentTime -= Time.deltaTime;

            if(currentTime < 0)
            {
                IsTime = true;
            }
        }
    }

    public void ResetCooldown()
    {
        IsTime = false;
        currentTime = cooldownTime;
    }

    public bool CanAction() { return IsTime; }

}

