using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private GameObject startImages;
    public Joystick joystick;
    public CharacterController characterController;

    private bool firstTouch = false;


    private void Start()
    {
        characterController.enabled = true;

    }

    void Update()
    {

        if (!firstTouch)
        {
            if (Input.touchCount > 0)
            {
                startImages.SetActive(false);
                firstTouch = true;
            }
        }
        else
        {
            MoveForward();
        }


        MoveWithController();

    }

    private void MoveWithController()
    {
        float moveHorizontal = joystick.Horizontal;
        Vector3 direction = new Vector3(moveHorizontal, 0f, 0f);

        if (direction.magnitude >= 0.1f)
        {
            characterController.Move(-direction * movementSpeed * Time.deltaTime);
        }
    }

    private void MoveForward()
    {
        Vector3 direction = new Vector3(0f, 0f, -1f);
        characterController.Move(direction * movementSpeed * Time.deltaTime);
    }

}
