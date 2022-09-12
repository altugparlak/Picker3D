using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickerJump")
        {
            Debug.Log("Landed!");
            other.GetComponent<PickerJump>().cantMove = true;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
    }
}
