using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    private Portal portal;
    private Transform playerCam;

    public Camera cam { get; private set; }

    private void Awake()
    {
        portal = GetComponentInParent<Portal>();
        cam = GetComponent<Camera>();
        playerCam = GameObject.FindGameObjectWithTag("CinemachineTarget").transform;

    }

    /*
    private void Update()
    {
        if (portal.otherPortal != null)
        {
            Vector3 playerOffsetFromPortal = playerCam.position - portal.otherPortal.transform.position;
            transform.position = portal.transform.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.transform.rotation, portal.otherPortal.transform.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCam.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }*/


    private void LateUpdate()
    {
        Vector3 playerOffsetFromPortal = playerCam.transform.position - portal.transform.position;
        //Vector3 playerOffsetFromPortal = playerCam.position - portal.otherPortal.transform.position;
        //transform.position = portal.transform.position + playerOffsetFromPortal;
        //Debug.LogError(portal.transform.forward + playerOffsetFromPortal);
        //cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, -playerOffsetFromPortal.z);

        float angularDeltaPortalRotations = Quaternion.Angle(portal.transform.rotation, playerCam.transform.rotation);
        Quaternion portalRotationDelta = Quaternion.AngleAxis(angularDeltaPortalRotations, Vector3.up);
        //Debug.LogError(angularDeltaPortalRotations);
        Vector3 newCamDir = portalRotationDelta * playerCam.forward;
        //Debug.LogError(newCamDir);
        //cam.transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);

        //cam.transform.SetPositionAndRotation(new Vector3(0f, 0f, -playerOffsetFromPortal.z), Quaternion.FromToRotation(Vector3.forward, transform.parent.position));

        //cam.transform.rotation = portalRotationDelta;
        if (portal.otherPortal != null)
        {
            /*
            var relativePos = transform.InverseTransformPoint(playerCam.position);
            relativePos = Vector3.Scale(relativePos, new Vector3(-1, 1, -1));
            cam.transform.position = portal.otherPortal.transform.TransformPoint(relativePos);

            var relativeRot = transform.InverseTransformDirection(playerCam.forward);
            relativeRot = Vector3.Scale(relativeRot, new Vector3(-1, 1, -1));
            cam.transform.forward = portal.otherPortal.transform.TransformDirection(relativeRot);*/



            /*
            Vector3 playerOffsetFromPortal = playerCam.transform.forward - portal.otherPortal.transform.forward;
            //Vector3 playerOffsetFromPortal = playerCam.position - portal.otherPortal.transform.position;
            //transform.position = portal.transform.position + playerOffsetFromPortal;
            //Debug.LogError(portal.transform.forward + playerOffsetFromPortal);
            transform.forward = portal.transform.forward + playerOffsetFromPortal;

            float angularDeltaPortalRotations = Quaternion.Angle(portal.transform.rotation, portal.otherPortal.transform.rotation);
            Quaternion portalRotationDelta = Quaternion.AngleAxis(angularDeltaPortalRotations, Vector3.up);
            Vector3 newCamDir = portalRotationDelta * playerCam.forward;
            transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);*/
        }

    }


    /*
    public void SetPortals(Transform _portal, Transform _otherPortal)
    {
        //this.gameObject.SetActive(true);
        
        transform.position = _otherPortal.position;
        //transform.rotation = otherPortal.rotation;

        Plane p = new Plane(-_otherPortal.forward, otherPortal.position);
        Vector4 clipPlaneWorldSpace = new Vector4(p.normal.x, p.normal.y, p.normal.z, p.distance);
        Vector4 clipPlaneCameraSpace =
            Matrix4x4.Transpose(Matrix4x4.Inverse(GetComponent<Camera>().worldToCameraMatrix)) * clipPlaneWorldSpace;

        var newMatrix = Camera.main.CalculateObliqueMatrix(clipPlaneCameraSpace);
        GetComponent<Camera>().projectionMatrix = newMatrix;

        //Vector3 relativePos = transform.InverseTransformPoint(otherPortal.position);
        //Debug.LogError(relativePos);
        //relativePos = Quaternion.Euler(0f, 180f, 0f) * relativePos;
        //transform.position = relativePos;

        //UniversalRenderPipeline.RenderSingleCamera(ScriptableRenderContext, GetComponent<Camera>());

        //transform.rotation = Quaternion.Inverse(otherPortal.rotation);
        //Quaternion rot180degrees = Quaternion.Euler(-otherPortal.eulerAngles);
        //transform.rotation = rot180degrees;
        //transform.rotation = Quaternion.LookRotation(portalToPlayer, Vector3.up);

        // Get direction from A to B
        //Vector3 posA = otherPortal.position;
        //Vector3 posB = playerCam.position;
        //Destination - Origin
        //Vector3 dir = (posB - posA).normalized;
        //Debug.LogError(dir);
        //transform.rotation = Quaternion.LookRotation(dir, Vector3.back);
    }*/
}
