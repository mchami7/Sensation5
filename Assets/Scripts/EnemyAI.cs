using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float viewDistance = 30f;
    [SerializeField] private float attackProximity = 10f;
    [SerializeField] private float projectileForce = 50f;
    [SerializeField] private float shotInterval = 0.5f;

    private float shotTime;
    private float rotationDamping = 2;

    private GameObject target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageEnemy")
        {
            Destroy(collision.gameObject);

            if (health > 0)
                health--;
            else
                Destroy(gameObject);
        }
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        Debug.DrawLine(target.transform.position, transform.position, Color.red);

        if (distance <= viewDistance)
        {
            LookTarget();

            if (distance <= attackProximity && (Time.time - shotTime) > shotInterval)
                Shoot();
        }
    }


    public void LookTarget()
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0f;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationDamping);
    }

    public void Shoot()
    {
        Debug.LogError("SHOOT");
        shotTime = Time.time;
        Vector3 targetDirection = target.transform.position - transform.position;
        GameObject proj = Instantiate(enemyProjectile, transform.position + targetDirection.normalized,
            Quaternion.LookRotation(target.transform.position - transform.position));
        Debug.LogError(Vector3.forward * projectileForce);
        proj.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileForce, ForceMode.Impulse);
        Destroy(proj, 5f);
    }
}
