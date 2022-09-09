using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    [SerializeField] private TextMeshPro pointText;

    private int totalObjectAmount = 20;
    private int collectedObjects = 0;

    void Start()
    {
        pointText.text = $" {0} / {totalObjectAmount}";

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            collectedObjects++;
            pointText.text = $" {collectedObjects} / {totalObjectAmount}";
        }
    }
}
