using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        Transform playerSpawnPosition = levels[0].transform.GetChild(0).gameObject.transform;
        SwitchToThePickerMove(playerSpawnPosition);
        //Instantiate(pickerMove, playerSpawnPosition, Quaternion.identity);

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
    }

    public void SwitchToThePickerJump(Transform spawnPosition)
    {
        if (pickerMoveOnTheScene != null)
            Destroy(pickerMoveOnTheScene);

        GameObject picker = Instantiate(pickerJump, spawnPosition.position, Quaternion.identity);
        pickerJumpOnTheScene = picker;
    }

}
