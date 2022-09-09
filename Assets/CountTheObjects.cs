using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTheObjects : MonoBehaviour
{
    [SerializeField] private float forceAmount = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Stop!");
            other.GetComponent<PickerMovement>().canMoveForward = false;
            other.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = true;
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, -forceAmount), ForceMode.Impulse);
        }
    }
}
