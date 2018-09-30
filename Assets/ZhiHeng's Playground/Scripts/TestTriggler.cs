using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggler : MonoBehaviour
{
    public ScrewSO screwSO;
    public ScrewDriverSO screwDriverSO;
    public ScrewAnimator targetScrewA;

    [Space(10)]
    public DottedLineComponent dottedLineComponent;
    public Vector3 point1;
    public Vector3 point2;

    [ContextMenu("Trigger ScrewAnim")]
    private void TriggerScrewAnim()
    {
        //targetScrewA.StartAnimation();
    }

    [ContextMenu("Trigger DottedLine")]
    private void TriggerDottedLine()
    {
        dottedLineComponent.SetPoints(point1, point2);
    }

    [ContextMenu("TriggerNight")]
    private void TriggerNight()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.NIGHT);
    }

    [ContextMenu("TriggerDay")]
    private void TriggerDay()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.MORNING);
    }
}
