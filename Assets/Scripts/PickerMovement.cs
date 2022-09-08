using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

    public Joystick joystick;
    public CharacterController characterController;


    private void Start()
    {
        characterController.enabled = true;

    }

    void Update()
    {

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
}
