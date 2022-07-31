using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Animations

   
    bool isChasing;

    //patroling
    public Vector3 walkPoint;
   public bool walkpointset;
    public float walkPointRange;

    // Attacking

    public float timebetweenAttacks;
    bool alreadyAttacked;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start ()
    {
        player = GameObject.Find("Fps Controller").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
       
    }
    
    private void Update ()
    {
        //check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);


        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();


        if(isChasing == true)
        {
           
        }










    }

    private void Patroling()
    {
       

        if (walkpointset == false) SearchWalkPoint();

        if (walkpointset)
            agent.SetDestination(walkPoint);
        

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
       
        if (distanceToWalkPoint.magnitude < 1f)
            walkpointset = false;
       
    }

    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-walkPointRange, walkPointRange);
        float RandomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + RandomX, transform.position.y,  transform.position.z + RandomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkpointset = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        isChasing = true;
       
    } 

    private void AttackPlayer()
    {

        
;


        agent.SetDestination(transform.position);
        
        transform.LookAt(player);

        if (!alreadyAttacked)
        { 
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timebetweenAttacks);
        } 
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
