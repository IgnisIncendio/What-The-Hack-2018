using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SectionManager : MonoBehaviour
{
    public BuildingManager m_Manager;

    public int stepVal = 0;

    public List<ConnectorBehaviour> RequiredConnection = new List<ConnectorBehaviour>();

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        InitiateSection();
    }

    public void InitiateSection()
    {
        foreach(ConnectorBehaviour part in RequiredConnection)
        {
            part.gameObject.SetActive(false);
            part.isOfficial = true;
            part.Initiate(this);
        }

        RequiredConnection[0].gameObject.SetActive(true);
    }
    
    public void changeStep(int changeVal)
    {
        RequiredConnection[stepVal].gameObject.SetActive(false);

        stepVal += changeVal;
        
        if(stepVal >= RequiredConnection.Count)
        {
            m_Manager.SetSection(1);
            return;
        }

        RequiredConnection[stepVal].gameObject.SetActive(true);
    }
}
