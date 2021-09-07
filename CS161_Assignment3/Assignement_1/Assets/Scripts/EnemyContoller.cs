using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyContoller : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public string targetName;

    private float timeBtwShots;
    // public float startTimeBtwShots;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag(targetName).transform;
        agent.SetDestination(target.position);

        if (timeBtwShots <= 0)
        {
            // Instantiate(projectile, transform.position, Quaternion.identity);
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // rb.AddForce(transform.up * 6f, ForceMode.Impulse);
            rb.AddForce(transform.forward * 50f, ForceMode.Impulse);
            timeBtwShots = Random.Range(1, 3);
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
