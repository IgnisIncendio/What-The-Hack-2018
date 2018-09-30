using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawn : MenuInteractable
{
    [SerializeField] private SpawnPointer spawnPointer;
    [SerializeField] private GameObject spawnedObject;
    [SerializeField] private Vector3 offset;

    public override void Press()
    {
        base.Press();
        spawnPointer.BeginSpawn(spawnedObject, offset);
    }
}
