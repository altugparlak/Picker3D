using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTheObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickerMovement>().canMoveForward = false;
            other.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
