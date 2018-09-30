using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    public ConnectorBehaviour currentConnector;

    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetTrigger("screwin");
        Invoke("EndAnimation", 2f);
    }

    private void Update()
    {
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