using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField] protected float trapDmg;
    protected bool damageDelay;
    protected abstract void OnActivation();
    protected abstract IEnumerator TrapBehaviour();
   

}
