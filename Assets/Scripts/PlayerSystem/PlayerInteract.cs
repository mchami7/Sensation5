using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : PlayerRaycast
{
    private new void FixedUpdate()
    {
        base.FixedUpdate();

        if (isRaycastHit)
            crosshair.GetComponent<Image>().color = crossColor;
        else
            crosshair.GetComponent<Image>().color = Color.white;

        if (_input.interact)
        {
            if (isRaycastHit && hitObject.GetComponent<Triggerable>() != null)
            {
                hitObject.GetComponent<Triggerable>().Interact();
            }
        }
    }


    
}
