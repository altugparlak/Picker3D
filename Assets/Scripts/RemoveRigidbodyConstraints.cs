using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRigidbodyConstraints : MonoBehaviour
{
    [SerializeField] public GameObject gates;
    public GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickerJump")
        {
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    public void RemoveChildColliders()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
