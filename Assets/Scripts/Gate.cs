using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject gateText;

    GameSession gameSession;
    PickerMovement pickerMovement;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickerCanMove()
    {
        if (gameSession.levelEnded)
        {
            pickerMovement = gameSession.pickerMoveOnTheScene.GetComponent<PickerMovement>();
            Transform playerSpawnTransform = gameSession.levelsInTheScene[1].transform.GetChild(0).gameObject.transform;
            pickerMovement.newLevelPosition = playerSpawnTransform.position;
            pickerMovement.canMoveToTheNextLevel = true;
            gateText.SetActive(false);
        }
        else
        {
            pickerMovement = gameSession.pickerMoveOnTheScene.GetComponent<PickerMovement>();
            pickerMovement.canMoveForward = true;
            gateText.SetActive(false);
        }
        
    }

    public void AudioPlay()
    {
        //audioSource.Play();
    }
}
