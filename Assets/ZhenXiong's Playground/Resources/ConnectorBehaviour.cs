using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorBehaviour : MonoBehaviour
{
    public SectionManager m_Manager;
    public Parts_ScriptableObject part_ScriptableObject;
    public bool isOfficial = false;

    public Transform followTransform;
    
    public void Initiate(SectionManager manage)
    {
        m_Manager = manage;
    }

    private void Update()
    {
        if (followTransform)
        {
            transform.position = followTransform.position;
            transform.rotation = followTransform.rotation;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ConnectorBehaviour>().part_ScriptableObject.m_PartName == part_ScriptableObject.m_PartName)
        {
            if (isOfficial)
            {   
                print("Connect");
                isOfficial = false;

                other.GetComponent<ConnectorBehaviour>().followTransform = transform;
                m_Manager.changeStep(1);
            }
        }
    }
}
