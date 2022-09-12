using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private RisingPlatform risingPlatform;
    [SerializeField] private TextMeshPro pointText;
    [SerializeField] private int requiredObjectAmount = 20;

    PickerMovement pickerMovement;
    GameSession gameSession;

    private int collectedObjects = 0;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        pointText.text = $" {0} / {requiredObjectAmount}";
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            collectedObjects++;
            pointText.text = $" {collectedObjects} / {requiredObjectAmount}";

            if (collectedObjects >= requiredObjectAmount)
            {
                pickerMovement = gameSession.pickerMoveOnTheScene.GetComponent<PickerMovement>();
                pickerMovement.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = false;
                Invoke("PlatformRiseUp", 1.2f);
            }
            else
            {
                gameSession.LevelFailed();
            }
        }
    }

    private void PlatformRiseUp()
    {
        risingPlatform.PlatformRise();
    }
}
