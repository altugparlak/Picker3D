﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private RisingPlatform risingPlatform;
    [SerializeField] private TextMeshPro pointText;
    [SerializeField] private int requiredObjectAmount = 20;

    PickerMovement pickerMovement;

    private int collectedObjects = 0;

    void Start()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
        pointText.text = $" {0} / {requiredObjectAmount}";

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            collectedObjects++;
            pointText.text = $" {collectedObjects} / {requiredObjectAmount}";

            if (collectedObjects >= requiredObjectAmount)
            {
                pickerMovement.transform.GetChild(0).gameObject.GetComponent<ObjectPusher>().boxCollider.enabled = false;
                Debug.Log("Good to go!");
                Invoke("PlatformRiseUp", 1.2f);
            }
        }
    }

    private void PlatformRiseUp()
    {
        risingPlatform.PlatformRise();
    }
}
