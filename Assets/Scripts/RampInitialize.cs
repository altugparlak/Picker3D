using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampInitialize : MonoBehaviour
{
    [SerializeField] private GameObject positionsHolder;
    [SerializeField] private Transform nextLevelTransform;

    private List<Transform> positions;
    private Transform target;

    GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        positions = new List<Transform>();
        for (int i = 0; i < positionsHolder.transform.childCount; i++)
        {
            positions.Add(positionsHolder.transform.GetChild(i));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("RampInitialize!");

            gameSession.SpawnNextLevel(nextLevelTransform);
            other.GetComponent<PickerMovement>().canMoveForward = false;
            GetClosestPosition(positions, other.transform.position);
            other.GetComponent<PickerMovement>().canMoveToTheClosestPoint = true;
            other.GetComponent<PickerMovement>().closestPoint = target.position;

        }
    }

    private Transform GetClosestPosition(List<Transform> postionsObjects, Vector3 playerPostion)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = playerPostion;
        foreach (Transform potentialTarget in postionsObjects)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        target = bestTarget;
        return bestTarget;
    }
}
