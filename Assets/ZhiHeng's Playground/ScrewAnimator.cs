using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewAnimator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField]
    private GameObject screw_Prefab;
    [SerializeField]
    private GameObject screwDriver;

    [Header("Other Parameters")]
    [SerializeField]
    private float screwStartYPosOffset;
    [SerializeField]
    private float screwdriverDistAwayFromScrew;
    [SerializeField]
    private float screwDownSpd;
    [SerializeField]
    private float rotationalSpd;
}
