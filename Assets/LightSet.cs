using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSet : MonoBehaviour
{
    [SerializeField] private Light[] lights;
    [SerializeField] private bool defaultState = false;
    private bool state;
    public bool State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;

            // Set lights
            foreach (Light light in lights)
            {
                light.enabled = state;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        State = defaultState;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleState()
    {
        State = State ? false : true;
    }
}
