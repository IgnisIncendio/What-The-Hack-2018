using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<SectionManager> ListOfSteps = new List<SectionManager>();

    public int stepVal = 0;

    public GameObject FullModel;

    private void Start()
    {
        Initiate();
    }

    void Initiate()
    {
        foreach(SectionManager section in ListOfSteps)
        {
            section.gameObject.SetActive(false);
            section.m_Manager = this;
        }

        ListOfSteps[stepVal].gameObject.SetActive(true);
    }
    
    public void SetSection(int changeVal)
    {
        ListOfSteps[stepVal].gameObject.SetActive(false);

        ++stepVal;
        
        if(stepVal >= ListOfSteps.Count)
        {
            GameObject newModel = Instantiate(FullModel, transform.position, transform.rotation);

            Destroy(gameObject);
            return;
        }

        ListOfSteps[stepVal].gameObject.SetActive(true);
    }
}
