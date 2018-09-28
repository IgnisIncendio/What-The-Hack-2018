using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockComponent : MonoBehaviour
{
    [Header("Block Type")]
    [SerializeField]
    private BlockType m_blockType;

    [System.Serializable]
    private class ConnectionPoints
    {
        [SerializeField] private string name;
        [SerializeField] private Collider collider;
    }
    [SerializeField]
    private List<ConnectionPoints> m_connectionPoints;

    private bool grabbed;

    private void Update()
    {
        if (!m_blockType)
        {
            Debug.LogWarning("No Block Type Defined on " + gameObject.name);
            return;
        }
    }

    public void ToggleGrabStatus()
    {
        grabbed = !grabbed;
    }

    public bool GetGrabbedStatus()
    {
        return grabbed;
    }    
}
