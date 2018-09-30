using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorBehaviour : MonoBehaviour
{
    public SectionManager m_Manager;
    public Parts_ScriptableObject part_ScriptableObject;
    public Material lineMat;
    public bool isOfficial = false;

    public GameObject screwAnimationPrefab;

    public Transform followTransform;
    
    public bool needAnimation = false;

    public ScrewAnimator screwAnimatorSetting;

    public void Initiate(SectionManager manage)
    {
        m_Manager = manage;
    }

    private void Start()
    {
        if (transform.parent.GetComponent<SectionManager>())
        {
            m_Manager = transform.parent.GetComponent<SectionManager>();
        }
        else if (transform.parent.parent.GetComponent<SectionManager>())
        {
            m_Manager = transform.parent.parent.GetComponent<SectionManager>();
        }

        if (!m_Manager)
        {
            needAnimation = false;
        }
    }

    private void Update()
    {
        if (followTransform)
        {
            transform.position = followTransform.position;
            transform.rotation = followTransform.rotation;
        }

        if (needAnimation && !isOfficial)
        {
            if (!GetComponent<DottedLineComponent>())
            {
                DottedLineComponent dlc = gameObject.AddComponent<DottedLineComponent>();
                dlc.lineMat = lineMat;
                dlc.lineWidth = 0.001f;
            }
        }

        if(GetComponent<DottedLineComponent>()  && m_Manager.RequiredConnection[m_Manager.stepVal].gameObject.activeInHierarchy)
        {
            GetComponent<DottedLineComponent>().SetPoints(transform.position, m_Manager.RequiredConnection[m_Manager.stepVal].transform.position);
        }
    }

    public GameObject screwDriver;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ConnectorBehaviour>() && other.GetComponent<ConnectorBehaviour>().part_ScriptableObject.m_PartName == part_ScriptableObject.m_PartName)
        {
            if (isOfficial)
            {
                isOfficial = false;

                other.GetComponent<ConnectorBehaviour>().followTransform = transform;

                if (!needAnimation)
                {
                    other.GetComponent<Collider>().enabled = false;
                    m_Manager.changeStep(1);


                    Collider[] allCollider = other.GetComponentsInChildren<Collider>();
                    foreach (Collider col in allCollider)
                    {
                        col.isTrigger = true;
                    }
                }
                else
                {
                    other.GetComponent<Collider>().enabled = true;
                    other.GetComponent<ConnectorBehaviour>().needAnimation = true;
                    other.GetComponent<ConnectorBehaviour>().m_Manager = m_Manager;
                    transform.gameObject.SetActive(false);
                    other.GetComponent<ConnectorBehaviour>().newPos = gameObject;

                    Collider[] allCollider = other.GetComponentsInChildren<Collider>();
                    foreach (Collider col in allCollider)
                    {
                        col.isTrigger = true;

                        //if (col.GetComponent<Rigidbody>())
                        //{
                        //    col.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        //}
                    }
                }

                SoundManager.instance.PlaySFX(SoundManager.SFX.FURNIT_CONN);
            }
        }
        else if (other.tag == "ScrewDriver" && needAnimation && m_Manager && !isOfficial)
        {
            // Spawning animation
            if (!other.gameObject.GetComponent<VRTK.VRTK_InteractableObject>().IsGrabbed())
            {
                GameObject newScrewAnimation = Instantiate(screwAnimationPrefab, transform.position, transform.rotation);
                newScrewAnimation.GetComponent<ScrewAnimator>().currentConnector = this;
                needAnimation = false;

                screwDriver = other.gameObject;

                screwDriver.SetActive(false);


                GetComponent<Collider>().enabled = false;
            }
        }
    }

    public GameObject newPos;
    public void NextStep()
    {
        print(newPos);
        newPos.transform.position -= transform.up * 0.005f;

        newPos.GetComponent<Collider>().enabled = false;

        screwDriver.gameObject.SetActive(true);
        screwDriver = null;
        m_Manager.changeStep(1);
        SoundManager.instance.PlaySFX(SoundManager.SFX.FURNIT_CONN);
    }
}
