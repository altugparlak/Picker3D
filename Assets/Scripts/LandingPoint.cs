using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LandingPoint : MonoBehaviour
{
    [SerializeField] private TextMeshPro landingPointText;
    [SerializeField] public int point;

    MoneyDiamond moneyDiamond;
    Transform pickerJumpTransform;

    private void Start()
    {
        landingPointText.text = point.ToString();
        moneyDiamond = FindObjectOfType<MoneyDiamond>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickerJump")
        {
            Debug.Log("Landed!");
            other.GetComponent<PickerJump>().cantMove = true;
            pickerJumpTransform = other.transform;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.gameObject.GetComponentInParent<RemoveRigidbodyConstraints>().RemoveChildColliders();
            Invoke("InvokeMoneyCollections", 1.5f);
            // Start Level Complete Animations!
        }
    }

    private void InvokeMoneyCollections()
    {
        //Also Switching Picker
        this.gameObject.GetComponentInParent<RemoveRigidbodyConstraints>().gameSession.SwitchToThePickerMove(pickerJumpTransform);
        moneyDiamond.GetGate(this.gameObject.GetComponentInParent<RemoveRigidbodyConstraints>().gates);
        moneyDiamond.SetEarnedPoint(point);
        moneyDiamond.CollectDiamonds();
    }
}
