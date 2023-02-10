using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour, IInteractable
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private AudioSource m_Source;
    [SerializeField] private Animator m_Animator;

    [SerializeField] private Animator targetObj;
    [SerializeField] private Material activeState;
    [SerializeField] private Material deactivatedState;

    private string animState;
    private List<Collision> _collisions = new List<Collision>();

    private void OnCollisionEnter(Collision collision)
    {
        animState = "OpenDoor";
        _collisions.Add(collision);
        m_Renderer.material = activeState;
        m_Animator.Play("FloorTriggerOn");
        m_Source.Play();
        Interact();
    }

    private void OnCollisionExit(Collision collision)
    {
        _collisions.Remove(collision);

        if (_collisions.Count == 0)
        {
            animState = "CloseDoor";
            m_Renderer.material = deactivatedState;
            m_Animator.Play("FloorTriggerOff");
            Interact();
        }
    }

    public void Interact()
    {
        targetObj.Play(animState);
    }
}
