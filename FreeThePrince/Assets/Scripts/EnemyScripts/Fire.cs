using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float spellDmg;
    private void Update()
    {
        SetDmgStatsWithBaseStats();
    }
    void SetDmgStatsWithBaseStats()
    {
        spellDmg = GetComponentInParent<BaseStats>().Dmg;
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.GetComponent<IDamageAble>() != null && other.GetComponent<StatusEffects>() != null)
        {
            other.GetComponent<StatusEffects>().TriggerEffect(3, StatusEffects.EnumStatusEffects.burning);
            other.GetComponent<IDamageAble>().TakeDmg(spellDmg);
        }
    }
}
