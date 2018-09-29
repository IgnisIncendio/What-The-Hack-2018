using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

public class FurnitureDataEditor : EditorWindow
{
    private static FurnitureDataEditor window;
    private static int furnitureDataSaved = 0;
    private static string rawFurnitureData = string.Empty;
    private static FurnitureData targetFurnitureData;
    private static bool retrivedLatestData = false;

    [MenuItem("Block Connections/Block Connections Editor")]
    private static void ShowWindow()
    {
        window = CreateInstance<FurnitureDataEditor>();
        var position = window.position;
        position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
        window.position = position;
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
            GUILayout.Label("Furniture Data");
            targetFurnitureData = (FurnitureData)EditorGUILayout.ObjectField(targetFurnitureData, typeof(FurnitureData), false);
        GUILayout.EndHorizontal();

        if (!targetFurnitureData)
            return;

        if (GUILayout.Button("Check Dependencies"))
            Selection.objects = EditorUtility.CollectDependencies(new FurnitureData[] { targetFurnitureData });

        if (GUILayout.Button("Restore Stored Furniture Data"))
        {
            RetriveLatestData();
        }

        if (targetFurnitureData && !retrivedLatestData)
        {
            RetriveLatestData();
            retrivedLatestData = true;
        }

        if (!targetFurnitureData && rawFurnitureData == string.Empty)
        {
            DeleteCachedData();
            retrivedLatestData = false;
        }

        GUILayout.Space(10);
        GUILayout.Label("Raw Data");
        rawFurnitureData = EditorGUILayout.TextArea(rawFurnitureData, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(150));
        GUILayout.Space(10);
        if (GUILayout.Button("Update Furniture Data"))
        {
            UpdateConnectionDatabase();
        }
        if(targetFurnitureData)
            GUILayout.Label(targetFurnitureData.GetNumOfConnections() + " Connections In Furniture Data");
        GUILayout.Space(10);
    }

    private void UpdateConnectionDatabase()
    {
        List<ComponentConnData> newBlockConnectionDataList = new List<ComponentConnData>();

        rawFurnitureData = rawFurnitureData.ToString().TrimEnd('\n');

        List<string> allConnData =
            rawFurnitureData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

        foreach (string connData in allConnData)
        {
            ComponentConnData newData = new ComponentConnData();

            List<string> blockData =
                connData.Split(new[] { " >> ", "-" }, StringSplitOptions.None).ToList();

            newData.blockAName = blockData[0];
            newData.blockAConnection = blockData[1];
            newData.blockBName = blockData[2];
            newData.blockBConnection = blockData[3];

            newBlockConnectionDataList.Add(newData);
        }

        try
        {
            targetFurnitureData.SetConnectionDataList(newBlockConnectionDataList);
        }
        catch(Exception e)
        {
            Debug.LogError("Failed to save Furniture Data");
        }
    }

    private void RetriveLatestData()
    {
        rawFurnitureData = string.Empty;

        if (!targetFurnitureData)
        {
            Debug.Log("Data Retrival failed");
            return;
        }

        List<ComponentConnData> blockConnectionDataList = targetFurnitureData.GetConnectionDataList();

        foreach(ComponentConnData blockConnectionData in blockConnectionDataList)
        {
            rawFurnitureData += blockConnectionData.blockAName + "-";
            rawFurnitureData += blockConnectionData.blockAConnection + " >> ";
            rawFurnitureData += blockConnectionData.blockBName + "-";
            rawFurnitureData += blockConnectionData.blockBConnection + "\n";
        }
        rawFurnitureData = rawFurnitureData.ToString().TrimEnd('\n');
        Repaint();
    }

    private void DeleteCachedData()
    {
        rawFurnitureData = string.Empty;
    }
}
