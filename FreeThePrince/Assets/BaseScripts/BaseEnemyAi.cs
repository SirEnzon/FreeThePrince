using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseEnemyAi : MonoBehaviour
{
    [SerializeField] protected Transform enemyTransform;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Transform enemyAttackCheck;
    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected LayerMask groundLayer;
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
    protected float randomX;
    protected float randomZ;

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckForPlayerInSightRange();
        CheckForPlayerInAttackRange();
        CheckIfHasToPatroll();
        CheckIfCanattack();
        CheckIfHasToChase();
        
       
    }
    protected void SearchWayPoint()
    {
        float randomZ = Random.Range(-walkingRange, walkingRange);
        float randomX = Random.Range(-walkingRange, walkingRange);
        enemyWalkPoint = enemyTransform.position + new Vector3(randomX, 0, randomZ);
        Debug.DrawRay(transform.position, Vector3.down, Color.blue);
        if (Physics.Raycast( enemyWalkPoint, -enemyTransform.up, 1f, groundLayer))
        {
            Debug.Log(Physics.Raycast(enemyWalkPoint, -enemyTransform.up, 1f, groundLayer));
            walkPointSet = true;
        }

    }
    protected void Patrolling()
    {
        Debug.DrawRay(enemyWalkPoint, Vector3.down, Color.blue);
        if (!walkPointSet) SearchWayPoint();
        if (walkPointSet)
        {
            enemyAgent.SetDestination(enemyWalkPoint);
        }
        distanceToWalkPoint =  enemyWalkPoint - enemyTransform.position;

        if (distanceToWalkPoint.magnitude <= 1f)
        {
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
        enemyAgent.SetDestination(playerTransform.position);
    }
    protected virtual void EnemyAttack()
    {
        if (canAttack)
        {
            Debug.Log("HELLLOOOOOOO");
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
            Debug.Log("ATTACK");
            EnemyAttack();
        }
    }
    protected  void CheckIfHasToChase()
    {
        if (!playerIsInAttackRange && playerIsInSightRange)
        {
            ChasePlayer();
        }
    }
    protected virtual IEnumerator AttackDelay(float attackCd)
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCd);
        canAttack = true;
    }


    protected void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(enemyAttackCheck.position, attackcheckRadius);
        Gizmos.DrawWireSphere(enemyTransform.position, sightRange);
        Gizmos.DrawWireSphere(enemyTransform.position, attackRange);
    } 

}
