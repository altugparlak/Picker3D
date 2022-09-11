using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerThrover : MonoBehaviour
{
    [SerializeField] private float forceAmount = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickerJump")
        {
            Debug.Log("Fırlat!");
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, forceAmount, -forceAmount), ForceMode.Impulse);
        }
    }
}
