using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private GameObject gateText;
    PickerMovement pickerMovement;

    void Start()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickerCanMove()
    {
        pickerMovement.canMoveForward = true;
        gateText.SetActive(false);
    }

    public void AudioPlay()
    {
        //audioSource.Play();
    }
}
