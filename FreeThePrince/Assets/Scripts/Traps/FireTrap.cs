using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : Trap
{

    [SerializeField] float timeBetweenFire;
    [SerializeField] float firePlayTime;
    ParticleSystem trapFireParticles;

    // Start is called before the first frame update
    void Start()
    {
        trapFireParticles = GetComponent<ParticleSystem>();
        OnActivation();
    }
    protected override void OnActivation()
    {
        StartCoroutine(TrapBehaviour());
    }

    protected override IEnumerator TrapBehaviour()
    {
        trapFireParticles.Play();
        while (firePlayTime >= 0)
        {
            firePlayTime -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        trapFireParticles.Stop();
        yield return new WaitForSeconds(timeBetweenFire);
        firePlayTime = 2;
        StartCoroutine(TrapBehaviour());
       
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.GetComponent<IDamageAble>() != null)
        {
            other.GetComponent<StatusEffects>().TriggerEffect(3, StatusEffects.EnumStatusEffects.burning);
        }
    }
}
