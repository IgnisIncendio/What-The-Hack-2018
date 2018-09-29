using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTime : MenuInteractable
{
    [SerializeField] private TimeOfDay timeOfDay;
    [SerializeField] private string timeName;

    public override void Press()
    {
        base.Press();
        timeOfDay.SetTimeOfDay(timeName);
    }
}
