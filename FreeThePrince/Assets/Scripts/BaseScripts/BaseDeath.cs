using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeath : MonoBehaviour,IOnDie
{
    //sound for death
    //particles
    //deathAnimation
    //drops
    public void OnDeath()
    {
        gameObject.SetActive(false);
    }
}
