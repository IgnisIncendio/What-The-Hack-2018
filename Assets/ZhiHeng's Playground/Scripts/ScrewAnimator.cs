using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    private bool runAnimation = false;

    private float screwDownSpd;
    private float rotationalSpd;

    private GameObject screw;
    private GameObject screwDriver;

    private void Update()
    {
        if(runAnimation && screw && screwDriver)
        {
            screw.transform.Translate(-transform.up * Time.deltaTime * screwDownSpd);
            screwDriver.transform.Translate(-transform.up * Time.deltaTime * screwDownSpd);
            screwDriver.transform.Rotate(new Vector3(0, rotationalSpd * Time.deltaTime, 0));

            if (Vector3.Distance(transform.position, screw.transform.position) < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public void StartAnimation(ScrewSO screwSO, ScrewDriverSO screwDriverSO)
    {
        runAnimation = true;

        screw = Instantiate(screwSO.GetPrefab(), transform.position + new Vector3(0, screwSO.GetStartDistFromHole(), 0), transform.rotation);
        screwDriver = Instantiate(screwDriverSO.GetPrefab(), transform.position + new Vector3(0, screwSO.GetStartDistFromHole(), 0), transform.rotation);
        screwDownSpd = screwDriverSO.GetScrewDownSpd();
        rotationalSpd = screwDriverSO.GetRotationalSpd();
        screw.transform.parent = transform;
        screwDriver.transform.parent = transform;
    }
}
