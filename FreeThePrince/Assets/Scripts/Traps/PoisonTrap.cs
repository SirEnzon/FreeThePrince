using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : Trap 
{
    [SerializeField] float poisonActivationRadius;
    [SerializeField] LayerMask triggerLayer;
    ParticleSystem poisonCloud;
    Coroutine poisonBurst;
    bool poisonCloudIsPlaying = false;

    void Start()
    {
        poisonCloud = GetComponentInChildren<ParticleSystem>();
    }
    private void Update()
    {
        CheckForTriggerTargets();
    }
    protected override void OnActivation()
    {
        if(poisonBurst == null && !poisonCloudIsPlaying)
        {
            poisonBurst = StartCoroutine(TrapBehaviour());
        }
    }

    protected override IEnumerator TrapBehaviour()
    {
        float poisonCloudPlayTime = 5;
       
        poisonCloud.Play();
        while(poisonCloudPlayTime >= 0)
        {
            poisonCloudIsPlaying = true;
            poisonCloudPlayTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        poisonCloudPlayTime = 5;
        poisonCloudIsPlaying = false;
        poisonBurst = null;
        poisonCloud.Stop();
    }
    void CheckForTriggerTargets()
    {
        bool poisonCanBeActivated = Physics.CheckSphere(gameObject.transform.position, poisonActivationRadius, triggerLayer);
        if( !poisonCloudIsPlaying && poisonCanBeActivated)
        {
            Debug.Log(poisonCloudIsPlaying);
            OnActivation(); 
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.GetComponent<IDamageAble>() != null)
        {
            other.gameObject.GetComponent<StatusEffects>().TriggerEffect(trapDmg, StatusEffects.EnumStatusEffects.poisened);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, poisonActivationRadius);
    }
}
