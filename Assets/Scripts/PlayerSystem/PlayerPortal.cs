using UnityEngine;
using UnityEngine.Events;

public class PlayerPortal : PlayerRaycast
{
    [SerializeField] private GameObject portalPrefab;

    public GameObject portalA { get; set; }
    public GameObject portalB { get; set; }

    public static UnityEvent OpenPortalOrangeEvent;
    public static UnityEvent OpenPortalBlueEvent;

    private void Awake()
    {
        OpenPortalBlueEvent = new UnityEvent();
        OpenPortalOrangeEvent = new UnityEvent();
    }

    private new void Start()
    {
        base.Start();

        OpenPortalBlueEvent.AddListener(ShootPortalBlue);
        OpenPortalOrangeEvent.AddListener(ShootPortalOrange);
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void ShootPortalBlue()
    {
        if (isRaycastHit)
        {
            float distance = Vector3.Distance(hitPoint, transform.position);
            distance /= 100f;   //to get percentage of value

            dualSense.RightTriggerEffectType = 0;
            dualSense.RightContinuousStartPosition = (1 - distance); //inverse relationship between distance and startPos on trigger
            dualSense.RightContinuousForce = 1f;

            if (portalA != null)
            {
                Destroy(portalA);
                portalA = null;
            }

            if (portalA == null)
            {
                portalA = Instantiate(portalPrefab);
                portalA.name = "Portal_A";

                portalA.transform.SetPositionAndRotation(hitPoint, Quaternion.FromToRotation(Vector3.forward, hitPointNormal));
                portalA.GetComponent<Portal>().SetupCamera(Portal.PortalType.Blue);

                Debug.Log("PORTAL A");

                if (portalB != null)
                    Portal.LinkPortals(portalA.GetComponent<Portal>(), portalB.GetComponent<Portal>());

            }
        }
    }
    public void ShootPortalOrange()
    {
        if (isRaycastHit)
        {
            float distance = Vector3.Distance(hitPoint, transform.position);
            distance /= 100f;   //to get percentage of value

            dualSense.LeftTriggerEffectType = 0;
            dualSense.LeftContinuousStartPosition = (1 - distance); //inverse relationship between distance and startPos on trigger
            dualSense.LeftContinuousForce = 1f;

            if (portalB != null)
            {
                Destroy(portalB);
                portalB = null;
            }

            if (portalB == null)
            {
                portalB = Instantiate(portalPrefab);
                portalB.name = "Portal_B";

                portalB.transform.SetPositionAndRotation(hitPoint, Quaternion.FromToRotation(Vector3.forward, hitPointNormal));
                portalB.GetComponent<Portal>().SetupCamera(Portal.PortalType.Orange);

                Debug.Log("PORTAL B");

                if (portalA != null)
                    Portal.LinkPortals(portalB.GetComponent<Portal>(), portalA.GetComponent<Portal>());
            }
        }
    }
}

