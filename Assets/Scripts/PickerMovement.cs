using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

    private Touch touch;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Debug.Log(touch.position);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Moved)
            {
                //transform.position = new Vector3(
                //    transform.position.x + touch.deltaPosition.x * -movementSpeed,
                //    transform.position.y,
                //    transform.position.z);
                //rb.velocity = new Vector2(direction.x, direction.y) * movementSpeed;


                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        }

    }
}
