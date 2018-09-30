using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MenuTVToggle : MenuInteractable
{
    [SerializeField] private Renderer emission;
    [SerializeField] private VideoPlayer videoPlayer;

    private bool state = false;
    
    public override void Press()
    {
        base.Press();

        if (state)
        {
            state = false;
            videoPlayer.Pause();
            emission.material.DisableKeyword("_EMISSION");
        }
        else
        {
            state = true;
            videoPlayer.Play();
            emission.material.EnableKeyword("_EMISSION");
        }
    }
}
