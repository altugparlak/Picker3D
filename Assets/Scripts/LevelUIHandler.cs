using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUIHandler : MonoBehaviour
{
    [SerializeField] private Image levelBox1;
    [SerializeField] private Image levelBox2;
    [SerializeField] private Image levelBox3;

    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;

    void Start()
    {
        //levelBox1.color = new Color32(255, 120, 66, 255);

        
    }

    public void SetLevelIndicators(int index)
    {
        currentLevelText.text = index.ToString();
        nextLevelText.text = (index + 1).ToString();
        levelBox1.color = new Color32(255, 255, 255, 255);
        levelBox2.color = new Color32(255, 255, 255, 255);
        levelBox3.color = new Color32(255, 255, 255, 255);
    }

    public void StageOneCompleted()
    {
        Debug.Log("StageOneCompleted");
        levelBox1.color = new Color32(255, 120, 66, 255);
        levelBox2.color = new Color32(255, 255, 255, 255);
        levelBox3.color = new Color32(255, 255, 255, 255);
    }

    public void StageTwoCompleted()
    {
        Debug.Log("StageTwoCompleted");

        levelBox1.color = new Color32(255, 120, 66, 255);
        levelBox2.color = new Color32(255, 120, 66, 255);
        levelBox3.color = new Color32(255, 255, 255, 255);
    }

    public void StageThreeCompleted()
    {
        Debug.Log("StageThreeCompleted");

        levelBox1.color = new Color32(255, 120, 66, 255);
        levelBox2.color = new Color32(255, 120, 66, 255);
        levelBox3.color = new Color32(255, 120, 66, 255);
    }
}
