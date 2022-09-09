using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPusher : MonoBehaviour
{
    [SerializeField] private float speedAmount = 5f;
    [SerializeField] private float forceAmount = 0.5f;


    public BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            //other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, -forceAmount), ForceMode.Force);
            other.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, -speedAmount);
            other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, forceAmount, 0f), ForceMode.Force);
        }
    }
}
