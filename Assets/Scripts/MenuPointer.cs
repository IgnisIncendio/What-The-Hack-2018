using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MenuPointer : VRTK_Pointer
{
    MenuInteractable currentInteractable;

    public override void PointerEnter(RaycastHit givenHit)
    {
        currentInteractable = givenHit.collider.GetComponent<MenuInteractable>();

        if (currentInteractable)
        {
            currentInteractable.HoverBegin();
        }
    }

    public override void PointerExit(RaycastHit givenHit)
    {
        if (currentInteractable)
        {
            currentInteractable.HoverEnd();
        }

        currentInteractable = null;
    }

    public override void OnSelectionButtonPressed(ControllerInteractionEventArgs e)
    {
        if (currentInteractable)
        {
            currentInteractable.Press();
        }
    }
}
