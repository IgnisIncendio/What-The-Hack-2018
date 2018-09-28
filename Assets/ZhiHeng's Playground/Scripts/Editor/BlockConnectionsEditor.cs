using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

public class BlockConnectionsEditor : EditorWindow
{
    private static BlockConnectionsEditor window;
    private static int connectionsSaved = 0;
    private static string rawConnectionsData = string.Empty;
    private static BlockConnectionDataStorage targetConnDataStorage;
    private static bool retrivedLatestData = false;

    [MenuItem("Block Connections/Block Connections Editor")]
    private static void ShowWindow()
    {
        window = CreateInstance<BlockConnectionsEditor>();
        var position = window.position;
        position.center = new Rect(0f, 0f, Screen.currentResolution.width, Screen.currentResolution.height).center;
        window.position = position;
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Space(10);

        targetConnDataStorage = 
            (BlockConnectionDataStorage)EditorGUI.ObjectField(new Rect(3, 3, position.width - 6, 20), "Connection Data", targetConnDataStorage, typeof(BlockConnectionDataStorage));

        GUILayout.Space(20);

        if (targetConnDataStorage)
        {
            if (GUI.Button(new Rect(3, 25, position.width - 6, 20), "Check Dependencies"))
                Selection.objects = EditorUtility.CollectDependencies(new BlockConnectionDataStorage[] { targetConnDataStorage });
            GUILayout.Space(20);
            if (GUILayout.Button("Restore Stored Conn Data"))
            {
                RetriveLatestData();
            }
        }

        if (targetConnDataStorage && !retrivedLatestData)
        {
            RetriveLatestData();
            retrivedLatestData = true;
        }

        if (!targetConnDataStorage && rawConnectionsData == string.Empty)
        {
            DeleteCachedData();
            retrivedLatestData = false;
        }

        GUILayout.Space(10);
        GUILayout.Label("Raw Connection Data");
        rawConnectionsData = EditorGUILayout.TextArea(rawConnectionsData, GUILayout.ExpandHeight(true), GUILayout.MaxHeight(150));
        GUILayout.Space(10);
        if (GUILayout.Button("Update Connection Database"))
        {
            UpdateConnectionDatabase();
        }
        if(targetConnDataStorage)
            GUILayout.Label(targetConnDataStorage.GetNumOfConnections() + " Connection In Database");
        GUILayout.Space(10);
    }

    private void UpdateConnectionDatabase()
    {
        List<BlockConnectionData> newBlockConnectionDataList = new List<BlockConnectionData>();

        rawConnectionsData = rawConnectionsData.ToString().TrimEnd('\n');

        List<string> allConnData =
            rawConnectionsData.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None).ToList();

        foreach (string connData in allConnData)
        {
            BlockConnectionData newData = new BlockConnectionData();

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
            targetConnDataStorage.SetConnectionDataList(newBlockConnectionDataList);
        }
        catch(Exception e)
        {
            Debug.LogError("Failed to save Connection Data");
        }
    }

    private void RetriveLatestData()
    {
        rawConnectionsData = string.Empty;

        if (!targetConnDataStorage)
        {
            Debug.Log("Data Retrival failed");
            return;
        }

        List<BlockConnectionData> blockConnectionDataList = targetConnDataStorage.GetConnectionDataList();

        foreach(BlockConnectionData blockConnectionData in blockConnectionDataList)
        {
            rawConnectionsData += blockConnectionData.blockAName + "-";
            rawConnectionsData += blockConnectionData.blockAConnection + " >> ";
            rawConnectionsData += blockConnectionData.blockBName + "-";
            rawConnectionsData += blockConnectionData.blockBConnection + "\n";
        }
        rawConnectionsData = rawConnectionsData.ToString().TrimEnd('\n');
        Repaint();
    }

    private void DeleteCachedData()
    {
        rawConnectionsData = string.Empty;
    }
}
