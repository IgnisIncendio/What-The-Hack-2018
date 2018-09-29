using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Part", menuName = "Scriptable/Part", order = 1)]
public class Parts_ScriptableObject : ScriptableObject
{
    public string m_PartName;

    [Multiline]
    public string m_Instruction;

    public bool CheckPartCompatibility(Parts_ScriptableObject partToCompare)
    {
        if(m_PartName == partToCompare.m_PartName)
        {
            return true;
        }
        return false;
    }
}
