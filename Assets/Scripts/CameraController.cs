using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        Vector3 reqiredPosition = target.position + offset;
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, reqiredPosition, smoothSpeed);
        transform.position = lerpedPosition;

        transform.LookAt(target);
    }

}
