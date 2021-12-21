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
        Debug.Log(attackCd);
    }
    protected override void EnemyAttack()
    {
        attackCd -= Time.deltaTime;
        if(attackCd <= 0 )
        {
            Debug.Log (attackCd);
            SpawnManager.instance.SpawnProjectiles(0.2f, 2, enemyProjectile, spawnPosition);
            attackCd = 2;
        }
        
    }
    protected override void CheckIfCanattack()
    {
        if (playerIsInAttackRange && playerIsInSightRange)
        {
            Debug.Log("ATTACK");
            this.EnemyAttack();
        }  
    }
    protected override IEnumerator AttackDelay(float attackCd)
    {
        yield return null;
    }
    
}
