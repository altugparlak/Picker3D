using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowGameObjectMovement : MonoBehaviour
{

    public bool lookingForPickerJump = false;
    public bool lookingForPickerMove = true;

    PickerMovement pickerMovement;
    PickerJump pickerJump;


    // Start is called before the first frame update
    void Start()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
        pickerJump = FindObjectOfType<PickerJump>();
    }
    
    private void FixedUpdate()
    {
        if (pickerMovement != null)
        {
            transform.position = new Vector3(0f, 0f, pickerMovement.transform.position.z - 1.2f);

        }
        if (pickerJump != null)
        {
            transform.position = new Vector3(0f, pickerJump.transform.position.y, pickerJump.transform.position.z - 1.2f);
        }

        if (lookingForPickerJump)
        {
            if (!lookingForPickerMove)
            {
                pickerJump = FindObjectOfType<PickerJump>();
            }
            if (pickerJump != null)
            {
                Debug.Log("PickerJump is found: " + pickerJump);
                lookingForPickerJump = false;
            }
        }
        if (lookingForPickerMove)
        {
            if (!lookingForPickerJump)
            {
                pickerMovement = FindObjectOfType<PickerMovement>();
            }
            if (pickerMovement != null)
            {
                Debug.Log("PickerMovement is found: " + pickerMovement);
                lookingForPickerMove = false;
            }

        }
    }

    public void findPickerMovement()
    {
        pickerMovement = FindObjectOfType<PickerMovement>();
    }
}
