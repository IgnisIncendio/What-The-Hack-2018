using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlockConnectionDataStorage : ScriptableObject
{
    [SerializeField]
    private List<BlockConnectionData> blockConnectionDataList = new List<BlockConnectionData>();

    public void SetConnectionDataList(List<BlockConnectionData> newData)
    {
        blockConnectionDataList.Clear();
        blockConnectionDataList = newData;
    }

    public List<BlockConnectionData> GetConnectionDataList()
    {
        return blockConnectionDataList;
    }

    public int GetNumOfConnections()
    {
        return blockConnectionDataList.Count;
    }
}

[System.Serializable]
public class BlockConnectionData
{
    public string blockAName;
    public string blockAConnection;
    public string blockBName;
    public string blockBConnection;
}
