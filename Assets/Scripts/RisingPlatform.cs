using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject gates;
    Animator animator;
    Animator gateAnimator;

    void Start()
    {
        animator = GetComponent<Animator>();
        gateAnimator = gates.GetComponent<Animator>();


        transform.position = new Vector3(transform.position.x, -0.4f, transform.position.z);
    }

    public void PlatformRise()
    {
        animator.SetTrigger("RisePlatform");
    }

    public void GateOpen()
    {
        gateAnimator.SetTrigger("GatesOpen");
    }
}
