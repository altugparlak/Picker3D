using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampStartPostion : MonoBehaviour
{
    [SerializeField] private GameObject rampStarter;
    GameSession gameSession;
    CameraFollowGameObjectMovement cameraFollowGameObjectMovement;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        cameraFollowGameObjectMovement = FindObjectOfType<CameraFollowGameObjectMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PickerMovement>().canMoveForward = true;
            other.GetComponent<PickerMovement>().canMoveToTheClosestPoint = false;
            cameraFollowGameObjectMovement.lookingForPickerJump = true;
            Destroy(other.gameObject);
            gameSession.SwitchToThePickerJump(other.gameObject.transform);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            gameSession.levelEnded = true;

        }
    }
}
