using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BaseEnemyAi
{
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform spawnPosition;
    [SerializeField] float attacksPerSecond;
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
        CheckIfCanattack();

    }
    public override void EnemyAttack()
    {
        enemyAnimations.speed = attacksPerSecond / attackCd;
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
