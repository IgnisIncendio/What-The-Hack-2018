using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    public ConnectorBehaviour currentConnector;

    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    
    public void StartAnimation()
    {
        animator.Play("screwin");
        Invoke("EndAnimation", 2f);

        if (currentConnector)
            transform.parent = currentConnector.transform.parent;
    }

    private void EndAnimation()
    {
        if(currentConnector)
            currentConnector.NextStep();
        Destroy(gameObject);
    }
}