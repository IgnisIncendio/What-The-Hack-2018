using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldSpaceText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro uiText;

    [SerializeField]
    private GameObject uiBG;

    private Camera targetCam;
    private bool showUI = false;

    private void Update()
    {
        if (!targetCam)
            targetCam = Camera.main;
        else
            uiBG.transform.rotation = Quaternion.LookRotation(transform.position - targetCam.transform.position);

        if (!showUI)
            uiBG.SetActive(false);
        else
        {
            uiBG.SetActive(true);
            return;
        }
    }

    public void SetUIText(string newText)
    {
        uiText.text = newText;
    }

    public void SetUIVisibility(bool visibility)
    {
        showUI = visibility;
    }
}
