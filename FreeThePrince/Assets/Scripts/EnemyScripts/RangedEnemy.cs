using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseEnemyAi
{
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform spawnPosition;
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        CheckIfCanattack();

    }
    protected override void EnemyAttack()
    {
        attackCd -= Time.deltaTime;
        if(attackCd <= 0 )
        { 
           
            GameObject go = enemyProjectile;
            SpawnManager.instance.SpawnProjectiles(1f, 1, go, spawnPosition);
            go.transform.forward = spawnPosition.forward;
            attackCd = 2;
        }
        
    }
    protected override void CheckIfCanattack()
    {
        if (playerIsInAttackRange && playerIsInSightRange)
        {
            enemyAnimations.SetBool("IsAttacking", true);
            enemyTransform.LookAt(playerTransform.position);
            this.EnemyAttack();
        }
        else
        {
            enemyAnimations.SetBool("IsAttacking", false);
        }
    }
    
    
}
