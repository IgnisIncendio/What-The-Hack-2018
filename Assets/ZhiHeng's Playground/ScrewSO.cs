using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScrewSO : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float startDistFromHole;

    public GameObject GetPrefab()
    {
        return prefab;
    }
    
    public float GetStartDistFromHole()
    {
        return startDistFromHole;
    }
}
