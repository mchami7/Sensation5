using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerRespawn : MonoBehaviour
{
    public static UnityEvent playerDeathEvent;
    public static UnityEvent playerRespawnEvent;
    public static Vector3 lastCheckpointPos;

    private void Awake()
    {
        playerDeathEvent = new UnityEvent();
        playerRespawnEvent = new UnityEvent();
    }

    private void Start()
    {
        playerDeathEvent.AddListener(OnDeath);
    }

    public void OnDeath()
    {
        PlayerBase.instance.transform.position = lastCheckpointPos;
        playerRespawnEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DamagePlayer")
            OnDeath();
    }
}
