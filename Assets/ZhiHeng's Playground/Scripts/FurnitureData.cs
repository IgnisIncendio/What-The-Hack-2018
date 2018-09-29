using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FurnitureData : ScriptableObject
{
    [SerializeField]
    private List<ComponentConnData> blockConnectionDataList = new List<ComponentConnData>();

    public void SetConnectionDataList(List<ComponentConnData> newData)
    {
        blockConnectionDataList.Clear();
        blockConnectionDataList = newData;
    }

    public List<ComponentConnData> GetConnectionDataList()
    {
        return blockConnectionDataList;
    }

    public int GetNumOfConnections()
    {
        return blockConnectionDataList.Count;
    }
}

[System.Serializable]
public class ComponentConnData
{
    public string blockAName;
    public string blockAConnection;
    public string blockBName;
    public string blockBConnection;
}
