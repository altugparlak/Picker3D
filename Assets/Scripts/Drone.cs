using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] public float angularSpeed = 200f;
    [SerializeField] public float movementSpeed = 0.8f;

    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject collectibleParent;

    [SerializeField] private GameObject collectible;

    Rigidbody rb;

    int waypointIndex = 0;
    public bool droneActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parent.transform.position = waypoints[waypointIndex].transform.position;

    }

    void Update()
    {
        Spin();

        if (droneActive)
            Move();


    }

    private void Spin()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = new Vector3(0f, angularSpeed * Time.deltaTime, 0f);
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
                GameObject collectibleGameObject =  Instantiate(collectible,
                    parent.transform.position, Quaternion.identity);
                collectibleGameObject.transform.SetParent(collectibleParent.transform);
                waypointIndex++;
            }
        }
        else
        {
            Destroy(parent.gameObject);
        }
    }
}
