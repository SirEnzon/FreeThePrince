using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] protected GameObject arrowPrefab;
    // [SerializeField] protected Transform spawnPoint;
    // // [SerializeField] protected string fireButton;
    // [SerializeField] protected float cooldown;
    public string InputButton { get { return InputButton; } protected set { InputButton = value; } }

    [Header("Effects")]
    [SerializeField] protected ParticleSystem vfx;
}
