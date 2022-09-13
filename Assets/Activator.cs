using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject spinners;
    [SerializeField] private GameObject sizeUp;
    [SerializeField] private GameObject sizeDown;

    [SerializeField] private bool spinnersControl;
    [SerializeField] private bool sizeUpControl;
    [SerializeField] private bool sizeDownControl;


    GameSession gameSession;
    //Random yapılacak
    private void Start()
    {
        if (spinnersControl)
        {
            spinners.SetActive(true);
            sizeUp.SetActive(false);
            sizeDown.SetActive(false);
        }
        else if (sizeUpControl)
        {
            spinners.SetActive(false);
            sizeUp.SetActive(true);
            sizeDown.SetActive(false);
        }
        else if (sizeDownControl)
        {
            spinners.SetActive(false);
            sizeUp.SetActive(false);
            sizeDown.SetActive(true);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 6.0f * 30f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (spinnersControl)
            {
                SpinnersActivation(other.gameObject);
            }
            else if (sizeUpControl)
            {
                SizeUp(other.gameObject);
            }
            else if (sizeDownControl)
            {
                SizeDown(other.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    private void SpinnersActivation(GameObject gameobject)
    {
        gameobject.GetComponent<PickerMovement>().ActivateSpinners();
        Debug.Log(gameObject.name);

    }

    private void SizeUp(GameObject gameobject2)
    {
        gameobject2.transform.localScale += new Vector3(0.2f, 0f, 0f);
    }

    private void SizeDown(GameObject gameobject3)
    {
        gameobject3.transform.localScale -= new Vector3(0.2f, 0f, 0f);
    }
}
