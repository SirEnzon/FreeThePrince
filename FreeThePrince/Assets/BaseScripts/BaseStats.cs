using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour,IDamageAble
{
    [SerializeField] Stats stats;
    float health;
    float speed;
    public float Speed { get { return speed; } }
    float dmg;
    public float Dmg { get { return dmg; } }
    bool isInvincible;
    public bool IsInvincible { get { return isInvincible; } set { isInvincible = value; } }
    float baseArmor;
    // Start is called before the first frame update
    protected void Start()
    {
        SetPlayerStats();
    }
    protected void SetPlayerStats()
    {
        health = stats.BaseHealth;
        speed = stats.BaseSpeed;
        dmg = stats.BaseDmg;
        baseArmor = stats.BaseArmor;

    }
    public void TakeDmg( float otherDmg)
    {
        if (!isInvincible)
        {
            health -= otherDmg - baseArmor;
        }
       
    }

}
