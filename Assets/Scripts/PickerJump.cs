using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerJump : MonoBehaviour
{
    [SerializeField] private float startSpeed = 2.5f;
    [SerializeField] private float endSpeed = 2.5f;

    Rigidbody rb;
    private bool firstTouch = false;
    public bool cantMove = false;

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
            if (!firstTouch)
            {
                //StartCoroutine(ChangeSpeed(startSpeed, endSpeed, 3f));
                firstTouch = true;
            }
            else
            {
                rb.velocity = new Vector3(0f, rb.velocity.y, -startSpeed);
            }

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
            startSpeed = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        startSpeed = v_end;
    }

}
