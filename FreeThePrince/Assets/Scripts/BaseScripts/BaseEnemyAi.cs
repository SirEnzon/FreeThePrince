using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAi : MonoBehaviour
{
    [SerializeField] protected Animator enemyAnimations;
    [SerializeField] protected Transform enemyTransform;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Transform enemyAttackCheck;
    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected LayerMask wallLayer;
    [SerializeField] protected float sightRange;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float walkingRange;
    [SerializeField] protected float attackcheckRadius;
    [SerializeField] protected float attackCd;
    protected Vector3 enemyWalkPoint;
    protected Vector3 distanceToWalkPoint;
    protected bool playerIsInAttackRange;
    protected bool playerIsInSightRange;
    protected bool walkPointSet = false;
    protected bool canAttack = true;
    bool hasBeenAttacked = false;
    protected float randomX;
    protected float randomZ;

    protected void Start()
    {
        enemyAgent.speed = GetComponent<BaseStats>().Speed;
    }
    protected virtual void Update()
    {
       
        if (!hasBeenAttacked)
        {
            CheckForWall();
            CheckIfHasToPatroll();
        }
        CheckForPlayerInSightRange();
        CheckForPlayerInAttackRange();
        CheckIfCanattack();
        CheckIfHasToChase();
       

    }
    protected void SearchWayPoint()
    {
        float randomZ = Random.Range(-walkingRange, walkingRange);
        float randomX = Random.Range(-walkingRange, walkingRange);
        enemyWalkPoint = enemyTransform.position + new Vector3(randomX, 0, randomZ);
        if (Physics.Raycast( enemyWalkPoint, -enemyTransform.up , 50f, groundLayer))
        {
            walkPointSet = true;
        }
       

    }
    protected void Patrolling()
    {
        Debug.DrawRay(transform.position, transform.forward *7f, Color.green);
        Debug.DrawRay(enemyWalkPoint, Vector3.down, Color.blue);
        if (!walkPointSet) SearchWayPoint();
        if (walkPointSet)
        {
            enemyAnimations.SetBool("isWalking", true);
            enemyAgent.SetDestination(enemyWalkPoint);
        }
        distanceToWalkPoint =  enemyWalkPoint - enemyTransform.position;

        if (distanceToWalkPoint.magnitude <= 1f)
        {
            enemyAnimations.SetBool("isWalking", false);
           walkPointSet = false;
        }
    }

    protected void CheckForPlayerInAttackRange()
    {
        playerIsInAttackRange = Physics.CheckSphere(enemyTransform.position, attackRange, playerLayer);
    }
    protected void CheckForPlayerInSightRange()
    {
        playerIsInSightRange = Physics.CheckSphere(enemyTransform.position, sightRange, playerLayer);
    }
    protected void ChasePlayer()
    { 
        Debug.DrawRay(enemyTransform.position , playerTransform.position - enemyTransform.position, Color.green);
        if (!Physics.Raycast(enemyTransform.position,playerTransform.position - enemyTransform.position, 10f, wallLayer))
        {
            
            enemyAgent.SetDestination(playerTransform.position);
            enemyAnimations.SetBool("isWalking", true);
        }
       
    }
    protected virtual void EnemyAttack()
    {
        if (canAttack && playerIsInAttackRange)
        {
            enemyAnimations.SetTrigger("isAttacking");
            enemyAnimations.SetBool("isStillAttacking", true);
            StartCoroutine(AttackDelay(attackCd));
            Collider[] attackableTargets = Physics.OverlapSphere(enemyAttackCheck.position, attackcheckRadius, playerLayer);         
            foreach (Collider attackableTarget in attackableTargets)
            {
                attackableTarget.gameObject.GetComponent<IDamageAble>().TakeDmg(GetComponent<BaseStats>().Dmg);
            }
        }
    }
    protected void CheckIfHasToPatroll()
    {
        if (!playerIsInAttackRange && !playerIsInSightRange)
        {
            Patrolling();
        }
    }
    protected virtual void CheckIfCanattack()
    {
        if (playerIsInAttackRange && playerIsInSightRange)
        {
            EnemyAttack();
        }
    }
    protected  void CheckIfHasToChase()
    {
        if (!playerIsInAttackRange && playerIsInSightRange || hasBeenAttacked)
        {
            ChasePlayer();
        }
    }
    protected void CheckForWall()
    {
        if (Physics.CheckSphere(transform.position, 3f,  wallLayer))
        {
            SearchWayPoint();
        }
    }
    protected virtual IEnumerator AttackDelay(float attackCd)
    {
        enemyAgent.speed = 0;
        canAttack = false;
        yield return new WaitForSeconds(attackCd);
        enemyAnimations.ResetTrigger("isAttacking");
        if (!playerIsInAttackRange)
        {
            enemyAnimations.SetBool("isStillAttacking", false);
        }
        enemyAgent.speed = GetComponent<BaseStats>().Speed;
        canAttack = true;
    }
    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(enemyAttackCheck.position, attackcheckRadius);
        Gizmos.DrawWireSphere(enemyTransform.position, sightRange);
        Gizmos.DrawWireSphere(enemyTransform.position, attackRange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            hasBeenAttacked = true;
            Debug.Log(hasBeenAttacked);
        }
    }

}
