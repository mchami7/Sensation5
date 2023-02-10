using DualSenseSample.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFeedbacks : MonoBehaviour
{
    public DualSenseTrigger dualSenseTrigger;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.LogError("RUMBLE");
        dualSenseTrigger.LeftTriggerEffectType = 0;
        dualSenseTrigger.LeftContinuousForce = 1;
        dualSenseTrigger.LeftContinuousStartPosition = 0.2f;

    }
}
