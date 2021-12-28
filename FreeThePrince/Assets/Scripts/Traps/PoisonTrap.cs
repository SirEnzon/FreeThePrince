using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonTrap : Trap 
{
    [SerializeField] LayerMask triggerLayer;
    ParticleSystem poisonCloud;
    Coroutine poisonBurst;

   

    // Start is called before the first frame update
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
        if(poisonBurst == null)
        {
            poisonBurst = StartCoroutine(TrapBehaviour());
        }
    }

    protected override IEnumerator TrapBehaviour()
    {
        poisonCloud.Play();
        yield return new WaitForSeconds(1);
        poisonBurst = null;
        poisonCloud.Stop();
    }
    void CheckForTriggerTargets()
    {
        if (Physics.CheckSphere(gameObject.transform.position, 2, triggerLayer))
        {
            OnActivation();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.GetComponent<IDamageAble>() != null)
        {
            other.gameObject.GetComponent<StatusEffects>().TriggerEffect(trapDmg, StatusEffects.EnumStatusEffects.poisened);
            other.gameObject.GetComponent<IDamageAble>().TakeDmg(trapDmg);
        }
    }
}
