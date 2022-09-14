using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buggy : MonoBehaviour
{
    [SerializeField] public float angularSpeed = 200f;
    [SerializeField] public float movementSpeed = 0.8f;
    [SerializeField] public float forceAmount = 1f;
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private GameObject parent;

    Rigidbody rb;

    int waypointIndex = 0;
    public bool buggyActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent.transform.position = waypoints[waypointIndex].transform.position;

    }

    void Update()
    {
        Spin();

        if (buggyActive)
            Move();


    }

    private void Spin()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, angularSpeed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object")
        {
            Vector3 forceDirection = collision.transform.position - parent.transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(forceAmount * forceDirection, ForceMode.Impulse);
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = movementSpeed * Time.deltaTime;
            parent.transform.position = Vector3.MoveTowards
                (transform.position, targetPosition, movementThisFrame);

            if (parent.transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(parent.gameObject);
        }
    }

}
