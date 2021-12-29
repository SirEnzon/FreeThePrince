using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StatusEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem currentlyPoisened;
    [SerializeField] VisualEffect currentlyBurning;
    [SerializeField] ParticleSystem currentlySlowed;
    VisualEffect go;
    ParticleSystem instance;
    Transform statusEffectVisualization;
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
        statusEffectVisualization = GetComponent<Transform>();
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
                        go =Instantiate(currentlyBurning, statusEffectVisualization.position, statusEffectVisualization.rotation);
                        go.gameObject.transform.SetParent(statusEffectVisualization, true);
                }
                    break;
                case EnumStatusEffects.poisened:
                    if (currentStatusEffect == null)
                    {
                        currentStatusEffect = StartCoroutine(PoisonDmg(statusEffectTime, 1,3));
                        instance = Instantiate(currentlyPoisened, statusEffectVisualization.position, statusEffectVisualization.rotation);
                        instance.gameObject.transform.SetParent(statusEffectVisualization, true);
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
        Destroy(go);
        currentStatusEffect = null;
    }
    IEnumerator PoisonDmg(float poisonTime,float delayBetweenPosionTicks,float poisonTicks)
    {
        for (int i = 0; i < poisonTicks ; i++)
        {
            stats.Health -= 1;
            yield return new WaitForSeconds(delayBetweenPosionTicks);
        }
        Destroy(instance);
        currentStatusEffect = null;
        
    }
    IEnumerator SlowApply(float slowTime,float slowAmount)
    {
        float currentSpeed = stats.Speed;
        stats.Speed -= slowAmount;
        yield return new WaitForSeconds(slowTime);
        stats.Speed = currentSpeed;
        Destroy(go);
        currentStatusEffect = null;
    }
}
