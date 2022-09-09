using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    PickerMovement pickerMovement;
    Animator animator;

    void Start()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
        animator = GetComponent<Animator>();
    }

    public void PlatformRise()
    {
        animator.SetTrigger("RisePlatform");
    }

    public void PickerMove()
    {
        pickerMovement.canMoveForward = true;
    }
}
