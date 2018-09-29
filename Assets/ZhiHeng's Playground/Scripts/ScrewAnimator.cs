using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    public ConnectorBehaviour currentConnector;

    private GameObject screw_screwDriver;
    public GameObject screw_screwDriver_prefab;

    private bool runAnimation = false;

    private float screwDownSpd;
    private float rotationalSpd;

    private void Update()
    {
        if(runAnimation && screw_screwDriver)
        {
            screw_screwDriver.transform.Translate(-transform.up * Time.deltaTime * screwDownSpd);
            screw_screwDriver.transform.Rotate(new Vector3(0, rotationalSpd * Time.deltaTime, 0));

            if (Vector3.Distance(transform.position, screw_screwDriver.transform.position) < 0.01f)
            {
                currentConnector.NextStep();
                Destroy(gameObject);
            }
            //parent follow connector
            transform.position = currentConnector.transform.position;
            transform.rotation = currentConnector.transform.rotation;
        }
    }
    
    public void StartAnimation()
    {
        runAnimation = true;

        screw_screwDriver = Instantiate(screw_screwDriver_prefab, transform.position + new Vector3(0, -0.5f, 0), transform.rotation);
        screw_screwDriver.transform.parent = transform;
    }
}