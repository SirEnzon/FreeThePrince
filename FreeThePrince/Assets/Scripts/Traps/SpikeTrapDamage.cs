using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDamage : MonoBehaviour
{
    [SerializeField] float trapDmg;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageAble>() != null && other.GetComponent<StatusEffects>() != null)
        {
            other.GetComponent<StatusEffects>().TriggerEffect(2f, StatusEffects.EnumStatusEffects.slowed);
            other.GetComponent<IDamageAble>().TakeDmg(trapDmg);
        }
    }
}
