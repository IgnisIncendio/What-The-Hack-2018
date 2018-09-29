using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource sfxAudioS;
    private AudioSource bgmAudioS;

    public enum SFX
    {
        UI_CLICK,
        UI_ERROR,
        FURNIT_CONN_SUCCESS,
        FURNIT_PLACED,
        FURNIT_COMPLETE
    }

    public enum BGM
    {
        MORNING,
        AFTERNOON,
        NIGHT
    }

    [Header("UI SFX")]
    [SerializeField] private AudioClip sfx_uiClick;
    [SerializeField] private AudioClip sfx_uiError;

    [Header("Furniture SFX")]
    [SerializeField] private AudioClip sfx_connectSuccessful;
    [SerializeField] private AudioClip sfx_furniturePlaced;
    [SerializeField] private AudioClip sfx_furnitureCompleted;

    [Header("Ambient BGM")]
    [SerializeField] private AudioClip bgm_morning;
    [SerializeField] private AudioClip bgm_afternoon;
    [SerializeField] private AudioClip bgm_night;

    private void Start()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        sfxAudioS = gameObject.AddComponent<AudioSource>();
        sfxAudioS.playOnAwake = false;
        sfxAudioS.loop = false;

        bgmAudioS = gameObject.AddComponent<AudioSource>();
        bgmAudioS.playOnAwake = false;
        bgmAudioS.loop = true;
    }

    public void PlayBGM(BGM bgm)
    {
        if (!bgmAudioS)
            return;

        AudioClip audioToPlay = sfx_uiError;
        switch (bgm)
        {
            case BGM.MORNING:
                audioToPlay = bgm_morning;
                break;
            case BGM.AFTERNOON:
                audioToPlay = bgm_afternoon;
                break;
            case BGM.NIGHT:
                audioToPlay = bgm_night;
                break;
        }

        bgmAudioS.clip = audioToPlay;
        bgmAudioS.Play();
    }

    public void PlaySFX(SFX sfx)
    {
        if (!sfxAudioS)
            return;

        AudioClip audioToPlay = sfx_uiError;
        switch (sfx)
        {
            case SFX.UI_CLICK:
                audioToPlay = sfx_uiClick;
                break;
            case SFX.UI_ERROR:
                audioToPlay = sfx_uiError;
                break;
            case SFX.FURNIT_CONN_SUCCESS:
                audioToPlay = sfx_connectSuccessful;
                break;
            case SFX.FURNIT_PLACED:
                audioToPlay = sfx_furniturePlaced;
                break;
            case SFX.FURNIT_COMPLETE:
                audioToPlay = sfx_furnitureCompleted;
                break;
        }

        sfxAudioS.clip = audioToPlay;
        sfxAudioS.Play();
    }
}
