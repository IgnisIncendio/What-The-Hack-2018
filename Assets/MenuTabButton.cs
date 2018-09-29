using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTabButton : MenuInteractable
{
    [SerializeField] private MenuTabs tabs;
    [SerializeField] private GameObject tab;

    public override void Press()
    {
        base.Press();
        tabs.SetTab(tab);
    }
}
