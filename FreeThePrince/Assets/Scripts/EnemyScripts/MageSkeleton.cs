using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseStats))]
public class MageSkeleton :BaseEnemyAi
{
    ParticleSystem fireSpell;
    private void Awake()
    {
        
        fireSpell = GetComponentInChildren<ParticleSystem>();
        
    }
    protected override void Update()
    {
        if (playerIsInAttackRange)
        {
            transform.LookAt(playerTransform);
        }
        base.Update();
    }
    public override void EnemyAttack()
    {
       
        if (!fireSpell.isPlaying )
        {
            enemyAnimations.SetBool("isAttacking", true);
            fireSpell.Play();  
        }
       
           
        
       
    }
    protected override void CheckIfCanattack()
    {
        if (!fireSpell.isPlaying)
        {
            base.CheckIfCanattack();
        }
        else if (!playerIsInAttackRange)
        {
            enemyAnimations.SetBool("isAttacking", false);
            fireSpell.Stop();
        }

    }
}
