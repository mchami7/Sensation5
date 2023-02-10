using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum PortalType
    {
        Blue,
        Orange
    }

    public Portal otherPortal { get; private set; }
    public Renderer portalRenderer { get; private set; }
    public PortalCamera portalCamera { get; private set; }
    public PortalTeleporter portalTeleporter { get; private set; }
    public bool isPlaced { get; set; }

    [Header("Portal Renderer Materials")]
    [SerializeField] private Material portalOrange_Mat;
    [SerializeField] private Material portalBlue_Mat;

    [Header("Portal Camera Materials")]
    [SerializeField] private Material cam_MatA;
    [SerializeField] private Material cam_MatB;

    private ParticleSystemRenderer particleSystemRenderer;
    private Material camMaterial;


    private void Awake()
    {
        portalRenderer = GetComponentInChildren<Renderer>();
        portalCamera = GetComponentInChildren<PortalCamera>();
        portalTeleporter = GetComponentInChildren<PortalTeleporter>();

        particleSystemRenderer = GetComponentInChildren<ParticleSystemRenderer>();
    }

    public static void LinkPortals(Portal p1, Portal p2)    //p1 is blue, p2 is orange
    {
        p1.otherPortal = p2;
        p2.otherPortal = p1;

        p1.portalRenderer.material = p2.camMaterial;
        p2.portalRenderer.material = p1.camMaterial;

        p1.portalTeleporter.targetPortal = p2.portalTeleporter.transform;
        p2.portalTeleporter.targetPortal = p1.portalTeleporter.transform;

        p1.isPlaced = true;
        p2.isPlaced = true;
    }

    
    public void SetupCamera(PortalType t)
    {
        if (portalCamera.cam.targetTexture != null)
            portalCamera.cam.targetTexture.Release();

        if (t == PortalType.Blue)
        {
            camMaterial = cam_MatA;
            particleSystemRenderer.material = portalBlue_Mat;
        }
        else
        {
            camMaterial = cam_MatB;
            particleSystemRenderer.material = portalOrange_Mat;
        }

        portalCamera.cam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camMaterial.mainTexture = portalCamera.cam.targetTexture;
    }
}
