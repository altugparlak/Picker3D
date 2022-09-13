using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 1f;
    [SerializeField] private float horizontalSpeed = 1f;
    [SerializeField] public GameObject spinner1;
    [SerializeField] public GameObject spinner2;


    //private GameObject startImages;
    public Joystick joystick;

    private bool firstTouch = false;
    public bool canMoveForward = false;
    public bool canMoveToTheClosestPoint = false;
    public bool canMoveToTheNextLevel = false;
    public bool pickerInTheStartPosition = false;
    public bool IsCountinueButtonClicked = true;
    public bool dragToStart = false;
    public Vector3 closestPoint;
    public Vector3 newLevelPosition;

    Rigidbody rb;
    CameraFollowGameObjectMovement cameraFollowGameObjectMovement;
    GameSession gameSession;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<FloatingJoystick>();
        cameraFollowGameObjectMovement = FindObjectOfType<CameraFollowGameObjectMovement>();
        gameSession = FindObjectOfType<GameSession>();
        DeactivateSpinners();
        cameraFollowGameObjectMovement.lookingForPickerMove = true;

    }

    void Update()
    {

        if (!firstTouch)
        {
            if (dragToStart && pickerInTheStartPosition && IsCountinueButtonClicked)
            {
                gameSession.everyObjectInTheStartScene.SetActive(false);
                firstTouch = true;
                canMoveForward = true;
            }
        }
        if (canMoveForward)
        {
            MoveForward();
            MoveWithControllerVelocity();
        }
        else if (canMoveToTheClosestPoint && !canMoveForward)
        {
            MovingToTheClosestPoint();
        }
        else if (canMoveToTheNextLevel)
        {
            MovingToTheNextLevel();
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

    private void MovingToTheClosestPoint()
    {
        // Move our position a step closer to the target.
        var step = 1 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, closestPoint, step);

    }

    private void MovingToTheNextLevel()
    {
        // Move our position a step closer to the target.
        var step = 3 * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, newLevelPosition, step);

    }

    public void ActivateSpinners()
    {
        spinner1.SetActive(true);
        spinner2.SetActive(true);
    }

    public void DeactivateSpinners()
    {
        spinner1.SetActive(false);
        spinner2.SetActive(false);
    }

}
