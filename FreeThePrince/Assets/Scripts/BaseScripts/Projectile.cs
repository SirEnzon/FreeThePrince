using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Projectile : MonoBehaviour
{
    [SerializeField] protected Stats projectileStats;
    [SerializeField] protected string targetTag;
    protected float lifeSpan = 2f;
    protected float projectileDmg;
    protected float projectileForce;
    protected Rigidbody rb;

    protected void Awake()
    {
        SetProjectileStats();
        rb = GetComponent<Rigidbody>();
    }
    protected void Start()
    {
        Init();
    }
    private void Update()
    {
        transform.forward = rb.velocity;
        transform.Rotate(Vector3.forward * 500 * Time.deltaTime);
    }

    public void Init()
    {
        rb.AddForce(transform.forward  * projectileForce, ForceMode.Impulse);
        Destroy(gameObject, lifeSpan);
    }
    protected void SetProjectileStats()
    {
        projectileDmg = projectileStats.BaseDmg;
        projectileForce = projectileStats.BaseSpeed;
        lifeSpan = projectileStats.BaseHealth;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
            other.gameObject.GetComponent<IDamageAble>().TakeDmg(projectileDmg);
            Destroy(gameObject);
        }

    }
}
