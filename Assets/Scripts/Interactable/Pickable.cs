using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip soundQueue;

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }

    public void Interact()
    {
        Debug.LogError("Carry box");
    }
}
