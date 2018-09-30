using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    public ConnectorBehaviour currentConnector;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void StartAnimation()
    {
        animator.Play("screwin");
        Invoke("EndAnimation", 3);
    }

    private void EndAnimation()
    {
        currentConnector.NextStep();
        Destroy(gameObject);
    }
}