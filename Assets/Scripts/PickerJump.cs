using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerJump : MonoBehaviour
{
    [SerializeField] private float defaultSpeed = 1.5f;
    [SerializeField] private float touchSpeedIncrement = 0.5f;

    private float currentSpeed = 1.5f;
    private bool firstTouch = false;
    public bool cantMove = false;
    public bool pickerIsJumped = false;

    Rigidbody rb;
    Touch touch;
    float elapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cantMove)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began && !pickerIsJumped)
                {
                    Debug.Log("Boost!");
                    currentSpeed += touchSpeedIncrement;
                    elapsed = 0.0f;
                    //StartCoroutine(ChangeSpeed(currentSpeed, defaultSpeed, 0.5f));
                }

            }
            if (currentSpeed != defaultSpeed)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, defaultSpeed, elapsed / 1f);
                elapsed += Time.deltaTime;

            }
            rb.velocity = new Vector3(0f, rb.velocity.y, -currentSpeed);
            //Debug.Log(currentSpeed);

        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f);

        }
        //Debug.Log(rb.velocity.z);
    }

    IEnumerator ChangeSpeed(float v_start, float v_end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            currentSpeed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            Debug.Log(currentSpeed);
            yield return null;
        }
        currentSpeed = v_end;
    }

}
//if (!firstTouch)
//{
//    //StartCoroutine(ChangeSpeed(startSpeed, endSpeed, 3f));
//    firstTouch = true;
//}
//else
//{
//    rb.velocity = new Vector3(0f, rb.velocity.y, -startSpeed);
//}