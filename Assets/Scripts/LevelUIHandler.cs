using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIHandler : MonoBehaviour
{
    [SerializeField] private Image levelBox1;
    [SerializeField] private Image levelBox2;
    [SerializeField] private Image levelBox3;

    void Start()
    {
        //levelBox1.color = new Color32(255, 120, 66, 255);
        levelBox1.color = new Color32(255, 255, 255, 255);
        levelBox2.color = new Color32(255, 255, 255, 255);
        levelBox3.color = new Color32(255, 255, 255, 255);


    }

    void Update()
    {
        
    }
}
