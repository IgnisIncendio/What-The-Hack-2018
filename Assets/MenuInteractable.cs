using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInteractable : MonoBehaviour
{
    [SerializeField] private Color hoverColor = new Color(1, 0.5f, 0.5f);
    private new Renderer renderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoverBegin()
    {
        renderer.material.color = hoverColor;
    }

    public void HoverEnd()
    {
        renderer.material.color = originalColor;
    }

    public virtual void Press()
    { }
}
