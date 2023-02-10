using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerPortal))]
[RequireComponent(typeof(PlayerPickup))]
[RequireComponent(typeof(PlayerInteract))]

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase instance { get; private set; }

    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerPortal PlayerPortal { get; private set; }
    public PlayerPickup PlayerPickup { get; private set; }
    public PlayerInteract PlayerInteract { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        PlayerMovement = GetComponent<PlayerMovement>();
        PlayerPortal = GetComponent<PlayerPortal>();
        PlayerPickup = GetComponent<PlayerPickup>();
        PlayerInteract = GetComponent<PlayerInteract>();
    }

}
