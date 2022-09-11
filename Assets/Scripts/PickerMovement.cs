﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float horizontalSpeed = 1f;

    //private GameObject startImages;
    public Joystick joystick;

    private bool firstTouch = false;
    public bool canMoveForward = false;

    Rigidbody rb;
    GameObject[] canvasObjects;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<FloatingJoystick>();
        canvasObjects = GameObject.FindGameObjectsWithTag("Canvas");

    }

    void Update()
    {

        if (!firstTouch)
        {
            if (Input.touchCount > 0)
            {
                //startImages.SetActive(false);

                foreach (GameObject image in canvasObjects)
                {
                    image.SetActive(false);
                }
                firstTouch = true;
                canMoveForward = true;
            }
        }
        if (canMoveForward)
        {
            MoveForward();
            MoveWithControllerVelocity();
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);
        }

    }

    private void MoveWithControllerVelocity()
    {
        float moveHorizontal = joystick.Horizontal;
        Vector3 direction = new Vector3(-moveHorizontal, 0f, rb.velocity.z);

        rb.velocity = direction * horizontalSpeed;
    }

    private void MoveForward()
    {
        Vector3 direction = new Vector3(0f, 0f, -1f);
        rb.velocity = direction * forwardSpeed;
    }

}
