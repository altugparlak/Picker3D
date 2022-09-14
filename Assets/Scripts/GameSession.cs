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

    [Header("Canvas")]
    [SerializeField] public GameObject levelCompleteScene;
    [SerializeField] public GameObject levelFailedScene;
    [SerializeField] public GameObject everyObjectInTheStartScene;
    [SerializeField] public GameObject dragToStartButton;
    [SerializeField] public GameObject restartButton;
    [SerializeField] public LevelUIHandler levelUIHandler;

    private const string delete = "PrefsTemizle";
    public const string levelTutucu = "level";


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
        Debug.Log("Level " + (lastSavedLevel+1) + " is Spawned!");
        levelsInTheScene = new List<GameObject>();
        GameObject level = Instantiate(levels[lastSavedLevel], new Vector3(0f, 0f, 0f), Quaternion.identity);
        levelsInTheScene.Add(level);

        Transform playerSpawnTransform = levels[lastSavedLevel].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnTransform);

        levelCompleteScene.SetActive(false);
        levelFailedScene.SetActive(false);
        levelUIHandler.SetLevelIndicators(lastSavedLevel + 1);
    }

    public void SpawnNextLevel(Transform nextLevelTransform)
    {
        int nextLevel = PlayerPrefs.GetInt(levelTutucu) + 1;
        Debug.Log("Level " + (nextLevel+1) + " is spawned!");

        GameObject level = Instantiate(levels[nextLevel], nextLevelTransform.position, Quaternion.identity);
        levelsInTheScene.Add(level);

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
        Debug.Log("Level " + (currentLevel+1) + " is restarted!");

        levelsInTheScene = new List<GameObject>();
        GameObject level = Instantiate(levels[currentLevel], new Vector3(0f, 0f, 0f), Quaternion.identity);
        levelsInTheScene.Add(level);
        Transform playerSpawnTransform = levels[currentLevel].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnTransform);

        levelCompleteScene.SetActive(false);
        levelFailedScene.SetActive(false);
        everyObjectInTheStartScene.SetActive(true);
        dragToStartButton.SetActive(true);
        restartButton.GetComponent<Button>().interactable = true;

    }

    private void Olustur()
    {
        if (!PlayerPrefs.HasKey(levelTutucu))
        {
            PlayerPrefs.SetInt(levelTutucu, 0);
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
        int playedLevel = PlayerPrefs.GetInt(levelTutucu);
        int newLevel = playedLevel + 1;
        PlayerPrefs.SetInt(levelTutucu, newLevel);
        Debug.Log("Level " + (newLevel+1) + " is saved!");
        levelUIHandler.SetLevelIndicators(newLevel + 1);

    }

}
