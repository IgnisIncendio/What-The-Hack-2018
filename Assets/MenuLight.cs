using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLight : MenuInteractable
{
    [SerializeField] private LightSet lightSet;

    public override void Press()
    {
        base.Press();
        lightSet.ToggleState();
    }
}
