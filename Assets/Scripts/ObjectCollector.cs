using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private BoxCollider frontWall;
    [SerializeField] private RisingPlatform risingPlatform;
    [SerializeField] private TextMeshPro pointText;
    [SerializeField] public int maxPossibleCollectibleObjects;

    [Header("Level Settings")]
    [SerializeField] public int gateNumber;


    PickerMovement pickerMovement;
    GameSession gameSession;
    LevelSettings levelSettings;

    private int requiredObjectAmount = 20;
    private int collectedObjects = 0;
    private bool levelFail = false;
    private bool counter = true;

    private const string levelTutucu = "level";
    public const string levelIndexTutucu = "levelIndex";
    public const string level1 = "level1"; // bir levelın kaç kere oynandığını tutmak istiyoruz
    public const string level2 = "level2";
    public const string level3 = "level3";
    public const string level4 = "level4";
    public const string level5 = "level5";
    public const string level6 = "level6";
    public const string level7 = "level7";
    public const string level8 = "level8";
    public const string level9 = "level9";
    public const string level10 = "level10";

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        levelSettings = FindObjectOfType<LevelSettings>();
        frontWall.enabled = true;
        if (maxPossibleCollectibleObjects == 0)
            maxPossibleCollectibleObjects = 15;

        //Debug.Log("For gate " + gateNumber + ": total objects is: " + maxPossibleCollectibleObjects);

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
        DifficultyAdjustmentForTheLevel();
        if (requiredObjectAmount > maxPossibleCollectibleObjects)
            requiredObjectAmount = maxPossibleCollectibleObjects;

        //Debug.Log(requiredObjectAmount);
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

    private void DifficultyAdjustmentForTheLevel()
    {
        int levelIndx = gameSession.spwanedNextLevelIndexHolder;
        //Debug.Log("Level Index Prefab: " + (levelIndx + 1));
        int difficultyAmount;
        switch (levelIndx)
        {
            case 9:
                difficultyAmount = PlayerPrefs.GetInt(level10);
                requiredObjectAmount += difficultyAmount;
                break;
            case 8:
                difficultyAmount = PlayerPrefs.GetInt(level9);
                requiredObjectAmount += difficultyAmount;
                break;
            case 7:
                difficultyAmount = PlayerPrefs.GetInt(level8);
                requiredObjectAmount += difficultyAmount;
                break;
            case 6:
                difficultyAmount = PlayerPrefs.GetInt(level7);
                requiredObjectAmount += difficultyAmount;
                break;
            case 5:
                difficultyAmount = PlayerPrefs.GetInt(level6);
                requiredObjectAmount += difficultyAmount;
                break;
            case 4:
                difficultyAmount = PlayerPrefs.GetInt(level5);
                requiredObjectAmount += difficultyAmount;
                break;
            case 3:
                difficultyAmount = PlayerPrefs.GetInt(level4);
                requiredObjectAmount += difficultyAmount;
                break;
            case 2:
                difficultyAmount = PlayerPrefs.GetInt(level3);
                requiredObjectAmount += difficultyAmount;
                break;
            case 1:
                difficultyAmount = PlayerPrefs.GetInt(level2);
                requiredObjectAmount += difficultyAmount;
                break;
            case 0:
                difficultyAmount = PlayerPrefs.GetInt(level1);
                requiredObjectAmount += difficultyAmount;
                break;
            default:
                break;


        }

    }
}
