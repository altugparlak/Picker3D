using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private BoxCollider frontWall;
    [SerializeField] private RisingPlatform risingPlatform;
    [SerializeField] private TextMeshPro pointText;

    [Header("Level Settings")]
    [SerializeField] public int gateNumber;


    PickerMovement pickerMovement;
    GameSession gameSession;
    LevelSettings levelSettings;

    private int requiredObjectAmount = 20;
    private int collectedObjects = 0;
    private bool levelFail = false;
    private bool counter = true;


    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        levelSettings = FindObjectOfType<LevelSettings>();
        frontWall.enabled = true;

        switch (gateNumber)
        {
            case 3:
                requiredObjectAmount = levelSettings.stageThreeRequiredCollectibleCounts;
                break;
            case 2:
                requiredObjectAmount = levelSettings.stageTwoRequiredCollectibleCounts;
                break;
            case 1:
                requiredObjectAmount = levelSettings.stageOneRequiredCollectibleCounts;
                break;
            default:
                requiredObjectAmount = levelSettings.stageOneRequiredCollectibleCounts;
                break;
        }

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
                frontWall.enabled = false;
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
