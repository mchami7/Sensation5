using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public static PortalTextureSetup instance { get; private set; }

    public Camera cameraA;
    public Camera cameraB;

    [SerializeField] private Material cameraMat_A;
    [SerializeField] private Material cameraMat_B;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void SetUpCams()
    {
        if (cameraA.targetTexture != null)
            cameraA.targetTexture.Release();

        cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat_A.mainTexture = cameraA.targetTexture;

        if (cameraB.targetTexture != null)
            cameraB.targetTexture.Release();

        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat_B.mainTexture = cameraB.targetTexture;

        cameraA.gameObject.SetActive(true);
        cameraB.gameObject.SetActive(true);
    }
}
