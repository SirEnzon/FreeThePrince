using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffects : MonoBehaviour
{

    BaseStats stats;
    Coroutine currentStatusEffect;
    public enum EnumStatusEffects
    {
        burning,
        poisened,
        slowed
    }
    private void Start()
    {
        stats = GetComponent<BaseStats>();
    }


    public void TriggerEffect(float statusEffectTime,EnumStatusEffects statusEffect)
    {
      
            switch (statusEffect)
            {
                case EnumStatusEffects.burning:
                    if (currentStatusEffect == null)
                    {
                        currentStatusEffect = StartCoroutine(BurnDamageApply(statusEffectTime));
                    }
                    break;
                case EnumStatusEffects.poisened:
                    if (currentStatusEffect == null)
                    {
                        currentStatusEffect = StartCoroutine(PoisonDmg(statusEffectTime, 0.5f));

                    }
                    break;
                case EnumStatusEffects.slowed:
                    if (currentStatusEffect == null)
                    {
                        currentStatusEffect = StartCoroutine(SlowApply(3, 3));
                    }
                    break;

            
        }
       
        
    }
    IEnumerator BurnDamageApply(float effectTime)
    {
        while(effectTime >= 0)
        {
            effectTime -= Time.deltaTime;
            stats.Health = Mathf.Lerp(stats.Health, stats.Health - 1, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        currentStatusEffect = null;
    }
    IEnumerator PoisonDmg(float posionTime,float delayBetweenPosionTicks)
    {
        while(posionTime >= 0)
        {
            stats.Health -= 2;
            yield return new WaitForSeconds(delayBetweenPosionTicks);
        }
        currentStatusEffect = null;
        
    }
    IEnumerator SlowApply(float slowTime,float slowAmount)
    {
        float currentSpeed = stats.Speed;
        stats.Speed -= slowAmount;
        yield return new WaitForSeconds(slowTime);
        stats.Speed = currentSpeed;
        currentStatusEffect = null;
    }
}
