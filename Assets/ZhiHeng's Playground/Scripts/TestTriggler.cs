using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTriggler : MonoBehaviour
{
    public ScrewSO screwSO;
    public ScrewDriverSO screwDriverSO;

    public ScrewAnimator targetScrewA;

    [ContextMenu("Trigger ScrewAnim")]
    private void TriggerScrewAnim()
    {
        targetScrewA.StartAnimation(screwSO, screwDriverSO);
    }
}
