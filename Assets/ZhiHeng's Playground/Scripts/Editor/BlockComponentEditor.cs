using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(BlockComponent))]
public class BlockComponentEditor : Editor
{
    private BlockComponent editorTarget;
    private SerializedProperty connectableBlocks;

    private void OnEnable()
    {
        editorTarget = (BlockComponent)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Space(10);

        GUILayout.Label("Debug Options");
        ShowButtons();
    }

    private void ShowButtons()
    {
        string grabBtntxt = "";

        if (editorTarget.GetGrabbedStatus() == true)
            grabBtntxt = "Set Ungrabbed";
        else
            grabBtntxt = "Set Grabbed";

        if(GUILayout.Button(grabBtntxt))
            editorTarget.ToggleGrabStatus();
    }
}
