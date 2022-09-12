using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyDiamond : MonoBehaviour
{
    [SerializeField] private Text pointText;

    private GameObject gates;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pointText.text = $"+ {200}";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectDiamonds()
    {
        animator.SetTrigger("CollectDiamonds");
    }
    public void DiamondsMove()
    {
        animator.SetTrigger("DiamondsMove");
    }

    public void SetEarnedPoint(int amount)
    {
        pointText.text = $"+ {amount}";
    }

    public void GetGate(GameObject gate)
    {
        gates = gate;
        //gateAnimator.SetTrigger("GatesOpen");
    }

    public void OpenTheGate()
    {
        gates.GetComponent<Animator>().SetTrigger("GatesOpen");
    }
}
