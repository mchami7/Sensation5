using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredEvent : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    public List<Triggerable> triggerables = new List<Triggerable>();

    public void CheckDoorConditions()
    {
        if (triggerables.Count == 2)
            m_Animator.Play("OpenDoor");
        else
            m_Animator.Play("CloseDoor");
    }
}
