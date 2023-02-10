using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform targetPortal { get; set; }

    public bool triggered = false;

    private Transform objToTeleport;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = true;
            objToTeleport = other.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = false;  
        }
    }

    private void Update()
    {
        if (triggered)
        {
            Vector3 portalToObj = objToTeleport.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToObj);

            //if this is true: player has moved across the portal
            if (dotProduct < 0f)
            {
                //teleportation
                float rotationDiff = Vector3.SignedAngle(transform.eulerAngles, targetPortal.eulerAngles, Vector3.forward);
                float _r = Vector3.Angle(transform.forward, targetPortal.forward);
                Debug.LogError(_r);

                //this should all be replaced by actually calculating the rotation forward from the portal's direction
                if (_r == 0f)
                {
                    if (rotationDiff == 0)
                    {
                        rotationDiff = _r;
                        rotationDiff += 180f;   //so player exits target portal from inversed rotation (linear direction)
                    }
                    else
                    {
                        if (rotationDiff > 50f || rotationDiff < -50f)
                        {
                            if (rotationDiff < 90 && rotationDiff > 0)
                            {
                                rotationDiff = 90;
                            }
                            else if (rotationDiff > -90 && rotationDiff < 0)
                            {
                                rotationDiff = -90;
                            }
                        }
                        else if (rotationDiff == 45)
                        {
                            rotationDiff = -90;
                        }
                        else if (rotationDiff == -45)
                        {
                            rotationDiff = 90;
                        }
                        else
                        {
                            rotationDiff = 0f;
                        }
                    }      
                }
                else
                {
                    if (rotationDiff > 50f || rotationDiff < -50f)
                    {
                        if (rotationDiff < 90 && rotationDiff > 0)
                        {
                            rotationDiff = -90;
                        }
                        else if (rotationDiff > -90 && rotationDiff < 0)
                        {
                            rotationDiff = 90;
                        }
                    }
                    else
                    {
                       if (rotationDiff == 45)
                       {
                            rotationDiff = 90;
                       }
                       else if (rotationDiff == -45)
                       {
                            rotationDiff = -90;
                       }
                    }
                }

                Debug.LogError(rotationDiff + " AFTER");

                objToTeleport.Rotate(Vector3.up, rotationDiff);

                //need to rotate position offset as well
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToObj;
                objToTeleport.position = targetPortal.position + positionOffset;
                triggered = false;
            }

        }
    }
}
