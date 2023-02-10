using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerPickup : PlayerRaycast
{
    [SerializeField] private Transform holdArea;
    [SerializeField] private float pickupForce = 150f;

    private GameObject objHeld;

    public static UnityEvent playerPickingUpEvent;

    private void Awake()
    {
        playerPickingUpEvent = new UnityEvent();    
    }
    private new void Start()
    {
        base.Start();
        playerPickingUpEvent.AddListener(ManagePickable);
    }

    private new void FixedUpdate()
    {
        base.FixedUpdate();

        if (isRaycastHit)
            crosshair.GetComponent<Image>().color = crossColor;
        else
            crosshair.GetComponent<Image>().color = Color.white;
    }

    private void Update()
    {
        if (objHeld != null)
            MoveObject();
    }

    public void ManagePickable()
    {
        if (_input.interact)
        {
            if (objHeld == null)
            {
                if (isRaycastHit && hitObject.GetComponent<Pickable>() != null)
                {
                    PickUpObject(hitObject);
                }
            }
            else
            {
                DropObject();
            }
        }
    }

    public void PickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            pickObj.GetComponent<Rigidbody>().useGravity = false;
            pickObj.GetComponent<Rigidbody>().drag = 10;
            pickObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            pickObj.transform.parent = holdArea;
            objHeld = pickObj;
        }
    }

    public void DropObject()
    {
        objHeld.GetComponent<Rigidbody>().useGravity = true;
        objHeld.GetComponent<Rigidbody>().drag = 1;
        objHeld.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        objHeld.transform.parent = null;
        objHeld = null;

    }

    public void MoveObject()
    {
        if (Vector3.Distance(objHeld.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - objHeld.transform.position);
            objHeld.GetComponent<Rigidbody>().AddForce(moveDirection * pickupForce);
        }
    }
}
