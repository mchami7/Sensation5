using DualSenseSample.Inputs;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform aimRaycast;
    [SerializeField] private float distance = 20f;
    [SerializeField] private GameObject fireBallPref;

    public static UnityEvent playerShootDamage;

    private void Awake()
    {
        playerShootDamage = new UnityEvent();
    }

    private void Start()
    {
        playerShootDamage.AddListener(Shoot);
    }

    public void Shoot()
    {
        GameObject instantiatedProjectile = Instantiate(fireBallPref, aimRaycast.position, aimRaycast.rotation);
        instantiatedProjectile.GetComponent<Rigidbody>().velocity = aimRaycast.TransformDirection(Vector3.forward) * distance;

        Destroy(instantiatedProjectile, 3f);
    }
}
