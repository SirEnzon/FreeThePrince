using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats", menuName = "Stats", order = 0)]

public class Stats : ScriptableObject
{
    [SerializeField] float baseHealth;
    public float BaseHealth { get{return baseHealth;} set { baseHealth = value; } }
    [SerializeField] float baseDmg;
    public float BaseDmg { get { return baseDmg; } set { baseDmg = value; } }
    [SerializeField] float baseArmor;
    public float BaseArmor { get { return baseArmor; } set { baseArmor = value; } }
    [SerializeField] float baseSpeed;
    public float BaseSpeed { get { return baseSpeed; } set { baseSpeed = value; } }
}
