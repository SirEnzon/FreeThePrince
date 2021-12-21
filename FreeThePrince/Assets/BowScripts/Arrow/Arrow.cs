using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class Arrow : MonoBehaviour
{
    [SerializeField] protected int damageValue = 10;
    [SerializeField] protected float lifeSpan = 2f;
    [SerializeField] protected float force = 100f;
    [SerializeField] private string targetTag;

    private Rigidbody rb;

    // Sound


    // property
    public int DamageValue
    {
        get { return damageValue; }
    }

    protected void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        if (rb.velocity.sqrMagnitude > 0)
        {
            transform.forward = rb.velocity;
        }
    }

    public void Init()
    {
        rb.AddForce(transform.forward * Time.deltaTime * force, ForceMode.Impulse);

        Destroy(gameObject, lifeSpan);
    }



    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject, lifeSpan);

    }
}
