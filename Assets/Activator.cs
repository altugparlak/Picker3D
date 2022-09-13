using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(0, 6.0f * 30f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickerMovement>().ActivateSpinners();
            Destroy(this.gameObject);
        }
    }
}
