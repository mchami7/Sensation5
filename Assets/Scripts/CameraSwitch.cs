/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera followCam;
    [SerializeField] private CinemachineVirtualCamera aimCam;

    private StarterAssetsInputs _input;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        if (_input.aim)
        {
            TurnOnAim();
        }
        else
        {
            TurnOffAim();
        }
    }

    public void TurnOnAim()
    {
        aimCam.Priority = 11;
    }

    public void TurnOffAim()
    {
        aimCam.Priority = 9;
    }
}
*/