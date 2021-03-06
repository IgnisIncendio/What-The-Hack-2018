﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSet : MonoBehaviour
{
    [SerializeField] private Lamp[] lamps;
    [SerializeField] private bool defaultState = false;
    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        SetState(defaultState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleState()
    {
        SetState(state ? false : true);
    }

    private void SetState(bool state)
    {
        this.state = state;
        foreach (Lamp light in lamps)
        {
            light.enabled = state;
        }
    }
}
