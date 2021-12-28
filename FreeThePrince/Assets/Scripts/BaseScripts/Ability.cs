using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] protected Projectile arrowPrefab;
    [SerializeField] protected Transform spawnPoint;
    // [SerializeField] protected string fireButton;
    [SerializeField] protected float cooldown;

    [Header("Effects")]
    [SerializeField] protected ParticleSystem vfx;
}
