using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private new Light light;
    [SerializeField] private Renderer emissionRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        light.enabled = true;
        emissionRenderer.material.EnableKeyword("_EMISSION");
    }

    private void OnDisable()
    {
        light.enabled = false;
        emissionRenderer.material.DisableKeyword("_EMISSION");
    }
}
