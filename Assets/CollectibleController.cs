using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] public bool collectibleAnimationActivation;
    [SerializeField] public bool objectDrop;
    public int collectibleCounts;

    int i = 0;

    void Start()
    {
        collectibleCounts = transform.childCount;
        if (objectDrop)
        {
            for (int i = 0; i < collectibleCounts; i++)
            {
                transform.GetChild(i).GetComponent<Rigidbody>().useGravity = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && collectibleAnimationActivation)
        {
            if (objectDrop)
            {
                StartCoroutine(DropTheObjects());
            }

        }
    }

    IEnumerator DropTheObjects()
    {
        yield return new WaitForSecondsRealtime(0.05f);
        if (i < collectibleCounts)
        {
            Rigidbody collectibleRB = transform.GetChild(i).GetComponent<Rigidbody>();
            collectibleRB.useGravity = true;
            StartCoroutine(DropTheObjects());
            i++;
        }
        else
        {
            i = 0;
        }

        
    }
}
