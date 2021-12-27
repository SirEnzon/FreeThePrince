using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlayerStats : BaseStats
{
    [SerializeField][Range(0,40)]  float stamina;
    public float Stamina { get { return stamina; } set { stamina = value; } }
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Update()
    {
        ClampStamina();
        base.Update();
    }
    void ClampStamina()
    {
        stamina = Mathf.Clamp(stamina, 0, 40);
    }
   

}
