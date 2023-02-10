using DualSenseSample.Inputs;
using StarterAssets;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Transform camRaycast;
    [SerializeField] protected GameObject crosshair;
    [SerializeField] protected DualSenseTrigger dualSense;
    [SerializeField] protected float raycastRange = 5f;
    [SerializeField] protected int mask = 3;
    [SerializeField] protected Color crossColor = Color.red;

    protected StarterAssetsInputs _input;
    protected GameObject hitObject;
    protected Vector3 hitPoint;
    protected Vector3 hitPointNormal;
    protected static bool isRaycastHit;
    

    public void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        dualSense.LeftTriggerEffectType = -1;
        dualSense.RightTriggerEffectType = -1;
    }

    public void FixedUpdate()
    {
        RaycastHit hit;
        int layerMask = 1 << mask;

        Debug.DrawRay(camRaycast.position, camRaycast.TransformDirection(Vector3.forward) * raycastRange, Color.blue);        

        if (Physics.Raycast(camRaycast.position, camRaycast.TransformDirection(Vector3.forward), out hit, raycastRange, layerMask))
        {
            isRaycastHit = true;
            hitObject = hit.collider.gameObject;
            hitPoint = hit.point;
            hitPointNormal = hit.normal;
            Debug.DrawRay(hitPointNormal, hitPointNormal * 10, Color.red);
        }
        else
        {
            isRaycastHit = false;
            hitObject = null;
        }
    }

}
