using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabs : MonoBehaviour
{
    [SerializeField] private GameObject[] tabs;
    [SerializeField] private GameObject defaultTab;

    // Start is called before the first frame update
    void Start()
    {
        SetTab(defaultTab);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTab(GameObject targetTab)
    {
        foreach (GameObject tab in tabs)
        {
            if (tab == targetTab) tab.SetActive(true);
            else tab.SetActive(false);
        }
    }
}
