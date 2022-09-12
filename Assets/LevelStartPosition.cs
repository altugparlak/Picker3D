using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartPosition : MonoBehaviour
{

    GameSession gameSession;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameSession = FindObjectOfType<GameSession>();
            if (!gameSession.levelEnded)
            {
                other.GetComponent<PickerMovement>().pickerInTheStartPosition = true;
                other.GetComponent<PickerMovement>().IsCountinueButtonClicked = true;
            }
            else
            {
                other.GetComponent<PickerMovement>().IsCountinueButtonClicked = false;
            }
            Debug.Log("Picker in the Start Position!");
            other.GetComponent<PickerMovement>().canMoveToTheNextLevel = false;
            other.GetComponent<PickerMovement>().canMoveForward = false;
            gameSession = FindObjectOfType<GameSession>();
            if (gameSession.levelsInTheScene.Count > 1)
                gameSession.levelCompleteScene.SetActive(true);
        }
    }
}
