using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTheObjects : MonoBehaviour
{
    [SerializeField] private ObjectCollector objectCollector;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickerMovement>().canMoveForward = false;
            other.GetComponent<PickerMovement>().DeactivateSpinners();
            other.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = true;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("LevelFailedCheck", 3f);
        }
    }

    private void LevelFailedCheck()
    {
        objectCollector.LevelFail();
    }
}
