using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextRevealer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<WorldSpaceText>().SetUIVisibility(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<WorldSpaceText>().SetUIVisibility(false);
    }
}
