using UnityEngine;
using VRTK;

public class SpawnPointer : VRTK_Pointer
{
    private GameObject currentObject;
    private Vector3 offset;

    public void BeginSpawn(GameObject currentObject, Vector3 offset)
    {
        enabled = true;
        this.currentObject = currentObject;
        this.offset = offset;
    }

    public override void OnSelectionButtonPressed(ControllerInteractionEventArgs e)
    {
        if (enabled)
        {
            enabled = false;

            // Spawn
            Instantiate(currentObject, pointerRenderer.GetDestinationHit().point + offset, currentObject.transform.rotation);
        }
    }
}