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
    private bool levelFail = false;
    private bool counter = true;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        pointText.text = $" {0} / {requiredObjectAmount}";
    }

    void Update()
    {
        if (levelFail && counter)
        {
            gameSession.LevelFailed();
            levelFail = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            collectedObjects++;
            pointText.text = $" {collectedObjects} / {requiredObjectAmount}";
            other.GetComponent<Collider>().isTrigger = false;
            if (collectedObjects >= requiredObjectAmount)
            {
                counter = false;
                pickerMovement = gameSession.pickerMoveOnTheScene.GetComponent<PickerMovement>();
                pickerMovement.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = false;
                Invoke("PlatformRiseUp", 1.2f);
            }
            else
            {
                Invoke("LevelFail", 3f);
            }
        }
    }

    public void LevelFail()
    {
        levelFail = true;
    }

    private void PlatformRiseUp()
    {
        risingPlatform.PlatformRise();
    }
}
