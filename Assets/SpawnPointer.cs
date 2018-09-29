using UnityEngine;
using VRTK;

public class SpawnPointer : VRTK_Pointer
{
    private GameObject currentObject;

    public void BeginSpawn(GameObject currentObject)
    {
        enabled = true;
        this.currentObject = currentObject;
    }

    public override void OnSelectionButtonPressed(ControllerInteractionEventArgs e)
    {
        if (enabled)
        {
            enabled = false;

            // Spawn
            Instantiate(currentObject, pointerRenderer.GetDestinationHit().point, currentObject.transform.rotation);
        }
    }
}