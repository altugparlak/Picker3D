using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerMovement : MonoBehaviour
{
    [SerializeField] public float rotateSpeed = 1f;
    public bool pull = true;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pull)
        {
            InnerMovement();
        }
        else
        {
            //push
            OuterMovement();
        }
    }

    private void InnerMovement()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0, 6.0f * rotateSpeed * Time.deltaTime, 0);
        //transform.Rotate(0, 6.0f * rotateSpeed * Time.deltaTime, 0);

    }
    private void OuterMovement()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0, -6.0f * rotateSpeed * Time.deltaTime, 0);

    }

}
