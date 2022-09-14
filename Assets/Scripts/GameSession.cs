using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [Header("Pickers")]
    [SerializeField] public GameObject pickerMove;
    [SerializeField] public GameObject pickerJump;
    [SerializeField] public GameObject pickerJumpOnTheScene;
    [SerializeField] public GameObject pickerMoveOnTheScene;


    [Header("Levels")]
    [SerializeField] public List<GameObject> levels;
    [SerializeField] public List<GameObject> levelsInTheScene;
    public bool levelEnded = false;
    public int levelSpawnIndex;
    public int spwanedNextLevelIndexHolder;


    [Header("Canvas")]
    [SerializeField] public GameObject levelCompleteScene;
    [SerializeField] public GameObject levelFailedScene;
    [SerializeField] public GameObject everyObjectInTheStartScene;
    [SerializeField] public GameObject dragToStartButton;
    [SerializeField] public GameObject restartButton;
    [SerializeField] public LevelUIHandler levelUIHandler;

    private const string delete = "PrefsTemizle";
    public const string levelTutucu = "level";
    public const string levelIndexTutucu = "levelIndex"; // levels listinde en son hangi levelı çağırdığımızı gösterir.

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


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameSession");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        PrefsleriTemizle();
        Olustur();
        int lastSavedLevel = PlayerPrefs.GetInt(levelTutucu);
        int lastSpawnedLevelIndex;
        lastSpawnedLevelIndex = PlayerPrefs.GetInt(levelIndexTutucu);
        levelSpawnIndex = lastSpawnedLevelIndex;

        Debug.Log("Level " + (lastSavedLevel + 1) + " is Spawned!");


        levelsInTheScene = new List<GameObject>();
        GameObject level = Instantiate(levels[levelSpawnIndex], new Vector3(0f, 0f, 0f), Quaternion.identity);
        levelsInTheScene.Add(level);

        PlayerPrefs.SetInt(levelIndexTutucu, levelSpawnIndex);
        Transform playerSpawnTransform = levels[levelSpawnIndex].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnTransform);

        levelCompleteScene.SetActive(false);
        levelFailedScene.SetActive(false);
        levelUIHandler.SetLevelIndicators(lastSavedLevel + 1);

        spwanedNextLevelIndexHolder = lastSpawnedLevelIndex;
    }

    public void SpawnNextLevel(Transform nextLevelTransform)
    {
        int nextLevel = PlayerPrefs.GetInt(levelTutucu) + 1;
        int levelSpawnIndexx;
        if (nextLevel > levels.Count - 1) // Is greater than our list of Levels
        {
            int randomLevel = Random.Range(0, 10);
            levelSpawnIndexx = randomLevel;
        }
        else
        {
            levelSpawnIndexx = nextLevel;
        }
        Debug.Log("Level " + (nextLevel+1) + " is spawned!");

        GameObject level = Instantiate(levels[levelSpawnIndexx], nextLevelTransform.position, Quaternion.identity);
        levelsInTheScene.Add(level);
        spwanedNextLevelIndexHolder = levelSpawnIndexx;
        //PlayerPrefs.SetInt(levelIndexTutucu, levelSpawnIndexx);


    }

    public void SwitchToThePickerMove(Transform spawnPosition)
    {
        if (pickerJumpOnTheScene!= null)
            Destroy(pickerJumpOnTheScene);

        GameObject picker = Instantiate(pickerMove, spawnPosition.position, Quaternion.identity);
        pickerMoveOnTheScene = picker;
        pickerMoveOnTheScene.GetComponent<PickerMovement>().dragToStart = false;
    }

    public void SwitchToThePickerJump(Transform spawnPosition)
    {
        if (pickerMoveOnTheScene != null)
            Destroy(pickerMoveOnTheScene);

        GameObject picker = Instantiate(pickerJump, spawnPosition.position, Quaternion.identity);
        pickerJumpOnTheScene = picker;
    }

    public void PickerInTheStartPosition()
    {
        dragToStartButton.SetActive(true);
        pickerMoveOnTheScene.GetComponent<PickerMovement>().pickerInTheStartPosition = true;
        pickerMoveOnTheScene.GetComponent<PickerMovement>().IsCountinueButtonClicked = true;

        everyObjectInTheStartScene.SetActive(true);
        levelCompleteScene.SetActive(false);

        levelEnded = false;

        GameObject removedLevel = levelsInTheScene[0];
        levelsInTheScene.Remove(levelsInTheScene[0]);
        Destroy(removedLevel);
    }

    public void DragToStartIsClicked()
    {
        pickerMoveOnTheScene.GetComponent<PickerMovement>().dragToStart = true;
        dragToStartButton.SetActive(false);
    }

    public void LevelFailed()
    {
        levelFailedScene.SetActive(true);
    }

    public void RestartTheLevel()
    {
        StartCoroutine(RestartLevel());
        restartButton.GetComponent<Button>().interactable = false;
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        Invoke("RestartOperations", 0.5f);
    }

    private void RestartOperations()
    {
        int currentLevel = PlayerPrefs.GetInt(levelTutucu);
        int levelSpawnIndexxx;
        int lastSpawnedLevelIndex;
        lastSpawnedLevelIndex = PlayerPrefs.GetInt(levelIndexTutucu);
        levelSpawnIndexxx = lastSpawnedLevelIndex;


        Debug.Log("Level " + (currentLevel+1) + " is restarted!");

        levelsInTheScene = new List<GameObject>();
        GameObject level = Instantiate(levels[levelSpawnIndexxx], new Vector3(0f, 0f, 0f), Quaternion.identity);
        levelsInTheScene.Add(level);
        PlayerPrefs.SetInt(levelIndexTutucu, levelSpawnIndexxx);

        Transform playerSpawnTransform = levels[levelSpawnIndexxx].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnTransform);

        levelCompleteScene.SetActive(false);
        levelFailedScene.SetActive(false);
        everyObjectInTheStartScene.SetActive(true);
        dragToStartButton.SetActive(true);
        restartButton.GetComponent<Button>().interactable = true;
        levelUIHandler.SetLevelIndicators(currentLevel+1);

    }

    private void Olustur()
    {
        if (!PlayerPrefs.HasKey(levelTutucu))
        {
            PlayerPrefs.SetInt(levelTutucu, 0);
        }

        if (!PlayerPrefs.HasKey(levelIndexTutucu))
        {
            PlayerPrefs.SetInt(levelTutucu, 0);
        }

        if (!PlayerPrefs.HasKey(level1))
        {
            PlayerPrefs.SetInt(level1, 0);
        }

        if (!PlayerPrefs.HasKey(level2))
        {
            PlayerPrefs.SetInt(level2, 0);
        }

        if (!PlayerPrefs.HasKey(level3))
        {
            PlayerPrefs.SetInt(level3, 0);
        }

        if (!PlayerPrefs.HasKey(level4))
        {
            PlayerPrefs.SetInt(level4, 0);
        }

        if (!PlayerPrefs.HasKey(level5))
        {
            PlayerPrefs.SetInt(level5, 0);
        }

        if (!PlayerPrefs.HasKey(level6))
        {
            PlayerPrefs.SetInt(level6, 0);
        }

        if (!PlayerPrefs.HasKey(level7))
        {
            PlayerPrefs.SetInt(level7, 0);
        }

        if (!PlayerPrefs.HasKey(level8))
        {
            PlayerPrefs.SetInt(level8, 0);
        }

        if (!PlayerPrefs.HasKey(level9))
        {
            PlayerPrefs.SetInt(level9, 0);
        }

        if (!PlayerPrefs.HasKey(level10))
        {
            PlayerPrefs.SetInt(level10, 0);
        }
    }

    private void PrefsleriTemizle()
    {
        if (!PlayerPrefs.HasKey(delete))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt(delete, 1);
            Debug.Log("Prefsler Temizlendi");
        }
    }

    public void SaveLevel()
    {
        int completedLevelIndex = PlayerPrefs.GetInt(levelIndexTutucu);
        int number = 1;
        switch (completedLevelIndex)
        {
            case 9:
                number = PlayerPrefs.GetInt(level10) + 1;
                PlayerPrefs.SetInt(level10, number);
                Debug.Log("level10 is played for " + number + " times.");
                break;
            case 8:
                number = PlayerPrefs.GetInt(level9) + 1;
                PlayerPrefs.SetInt(level9, number);
                Debug.Log("level9 is played for " + number + " times.");
                break;
            case 7:
                number = PlayerPrefs.GetInt(level8) + 1;
                PlayerPrefs.SetInt(level8, number);
                Debug.Log("level8 is played for " + number + " times.");
                break;
            case 6:
                number = PlayerPrefs.GetInt(level7) + 1;
                PlayerPrefs.SetInt(level7, number);
                Debug.Log("level7 is played for " + number + " times.");
                break;
            case 5:
                number = PlayerPrefs.GetInt(level6) + 1;
                PlayerPrefs.SetInt(level6, number);
                Debug.Log("level6 is played for " + number + " times.");
                break;
            case 4:
                number = PlayerPrefs.GetInt(level5) + 1;
                PlayerPrefs.SetInt(level5, number);
                Debug.Log("level5 is played for " + number + " times.");
                break;
            case 3:
                number = PlayerPrefs.GetInt(level4) + 1;
                PlayerPrefs.SetInt(level4, number);
                Debug.Log("level4 is played for " + number + " times.");
                break;
            case 2:
                number = PlayerPrefs.GetInt(level3) + 1;
                PlayerPrefs.SetInt(level3, number);
                Debug.Log("level3 is played for " + number + " times.");
                break;
            case 1:
                number = PlayerPrefs.GetInt(level2) + 1;
                PlayerPrefs.SetInt(level2, number);
                Debug.Log("level2 is played for " + number + " times.");
                break;
            case 0:
                number = PlayerPrefs.GetInt(level1) + 1;
                PlayerPrefs.SetInt(level1, number);
                Debug.Log("level1 is played for " + number + " times.");
                break;
            default:
                break;


        }
        int playedLevel = PlayerPrefs.GetInt(levelTutucu);
        int newLevel = playedLevel + 1;
        PlayerPrefs.SetInt(levelTutucu, newLevel);
        PlayerPrefs.SetInt(levelIndexTutucu, spwanedNextLevelIndexHolder);
        Debug.Log("Level " + (newLevel+1) + " is saved!");
        levelUIHandler.SetLevelIndicators(newLevel + 1);

    }


}
