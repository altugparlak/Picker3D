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
            other.GetComponent<PickerJump>().pickerIsJumped = true;
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, forceAmount-0.5f, -forceAmount), ForceMode.Impulse);
            other.transform.rotation = Quaternion.Euler(41, 0, 0);
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }
}
