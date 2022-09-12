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
        pickerMovement = gameSession.pickerMoveOnTheScene.GetComponent<PickerMovement>();
        pickerMovement.canMoveForward = true;
        gateText.SetActive(false);
    }

    public void AudioPlay()
    {
        //audioSource.Play();
    }
}
