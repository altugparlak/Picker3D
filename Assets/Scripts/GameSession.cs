using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        levelsInTheScene = new List<GameObject>();
        GameObject level = Instantiate(levels[0], new Vector3(0f, 0f, 0f), Quaternion.identity);
        levelsInTheScene.Add(level);

        Transform playerSpawnTransform = levels[0].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnTransform);
        //Instantiate(pickerMove, playerSpawnPosition, Quaternion.identity);

        levelCompleteScene.SetActive(false);
        levelFailedScene.SetActive(false);

    }

    public void SpawnNextLevel(Transform nextLevelTransform)
    {
        GameObject level = Instantiate(levels[0], nextLevelTransform.position, Quaternion.identity);
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
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
