using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    public LayerMask whatGround, whatTarget;

    // Moving
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    // Shooting
    public float timeBtwAtcks;
    bool alreadyAttacked;
    public GameObject projectile;

    // Status
    public float sightRange, attackRange;
    public bool targetInSightRange, targetInAttackRange;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player2").transform;            // Change this
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatTarget);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatTarget);

        if (!targetInSightRange && !targetInAttackRange) Patrolling();
        if (targetInSightRange && !targetInAttackRange) ChaseTarget();
        if (targetInSightRange && targetInAttackRange) AttackTarget();
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatGround))
        {
            walkPointSet = true;
        }
    }

    private void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);

        if (!alreadyAttacked)
        {
            // shooting code;
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            // rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBtwAtcks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
