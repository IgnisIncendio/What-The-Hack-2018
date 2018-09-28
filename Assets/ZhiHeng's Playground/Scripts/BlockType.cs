using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BlockType : ScriptableObject
{
    [SerializeField]
    private string type;

    private string GetType()
    {
        return type;
    }
}
