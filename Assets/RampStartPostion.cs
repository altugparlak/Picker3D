using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampStartPostion : MonoBehaviour
{
    [SerializeField] private GameObject rampStarter;
    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickerMovement>().canMoveForward = true;
            other.GetComponent<PickerMovement>().canMoveToTheClosestPoint = false;

            this.gameObject.GetComponent<BoxCollider>().enabled = false;

            Destroy(other.gameObject);
            Instantiate(gameSession.pickerJump.gameObject, other.gameObject.transform.position, Quaternion.identity);
        }
    }
}
