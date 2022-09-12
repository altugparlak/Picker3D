using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] public List<GameObject> levels;
    [SerializeField] public GameObject pickerMove;
    [SerializeField] public GameObject pickerJump;


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
        
        Instantiate(levels[0], new Vector3(0f, 0f, 0f), Quaternion.identity);

        Vector3 playerSpawnPosition = levels[0].transform.GetChild(0).gameObject.transform.position;
        Instantiate(pickerMove, playerSpawnPosition, Quaternion.identity);


    }

}
