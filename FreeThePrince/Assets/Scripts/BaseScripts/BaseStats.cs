using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour,IDamageAble
{
    [SerializeField] Stats stats;
    [SerializeField] float health;
    public float Health { get { return health; } set { health = value; } }
    float speed;
    public float Speed { get { return speed; }set{ speed = value; } }
    float dmg;
    public float Dmg { get { return dmg; } }
    bool isInvincible;
    public bool IsInvincible { get { return isInvincible; } set { isInvincible = value; } }
    static bool thisIsDead;
    static public bool ThisIsDead { get { return thisIsDead; } set { thisIsDead = value; } }
    float baseArmor;
    float maxHealth;
    // Start is called before the first frame update
    protected virtual  void Awake()
    {
        maxHealth = stats.BaseHealth;
        SetStats();
    }
    protected virtual void Update()
    {
        ClampHealth();
        CheckIfThisIsDead();
    }
    protected void SetStats()
    {
        health = stats.BaseHealth;
        speed = stats.BaseSpeed;
        dmg = stats.BaseDmg;
        baseArmor = stats.BaseArmor;

    }
    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    public void TakeDmg( float otherDmg)
    {
        if (!isInvincible)
        {
            health -= otherDmg - baseArmor;
        }
       
    }
    void CheckIfThisIsDead()
    {
        if(health <= 0)
        {
            GetComponent<IOnDie>().OnDeath();
        }
    }


}
