using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseStats))]
public class MageSkeleton :BaseEnemyAi
{
    ParticleSystem fireSpell;
    bool spellIsPlaying = false;
    float spellDmg;

    private void Awake()
    {
        
        fireSpell = GetComponentInChildren<ParticleSystem>();
        
    }
    private void Start()
    {
        SetSpellStats();
    }
    private void Update()
    {
        if (playerIsInAttackRange)
        {
            transform.LookAt(playerTransform);
        }
        base.Update();
    }
    protected override void EnemyAttack()
    {
       
        if (!fireSpell.isPlaying)
        {
            fireSpell.Play();
            StartCoroutine(AttackDelay(attackCd));   
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
            fireSpell.Stop();
        }

    }
    void SetSpellStats()
    {  
        spellDmg = GetComponentInParent<BaseStats>().Dmg;
    }
    protected override IEnumerator AttackDelay(float attackCd)
    {
        while(attackCd >= 0)
        {
            attackCd -= Time.deltaTime;
            spellIsPlaying = true;
            yield return new WaitForEndOfFrame();
        }
        spellIsPlaying = false;
    }
}
