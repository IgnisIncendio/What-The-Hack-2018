using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScrewDriverSO : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float screwDownSpd;
    [SerializeField]
    private float rotationalSpd;

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public float GetScrewDownSpd()
    {
        return screwDownSpd;
    }

    public float GetRotationalSpd()
    {
        return rotationalSpd;
    }
}