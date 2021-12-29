using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawTrap : Trap
{
    [SerializeField] Transform sawWheel;
    [SerializeField] Vector3 movementDirection;
    [SerializeField] float sawWheelMoveRange;
     float sawWheelSpeed = 10;
     float sawWheelRotationSpeed = 500;

    private void Start()
    {
        movementDirection = Vector3.ClampMagnitude(movementDirection, 1);
        OnActivation();
    }
    void Update()
    {
        sawWheel.Rotate(Vector3.forward * sawWheelRotationSpeed * Time.deltaTime);
    }
    protected override void OnActivation()
    {
        StartCoroutine(TrapBehaviour());
    }

    protected override IEnumerator TrapBehaviour()
    {
        float sawWheelMoveRangeIEnum = sawWheelMoveRange;

        while(sawWheelMoveRangeIEnum >= 0)
        {
            sawWheelMoveRangeIEnum -= Time.deltaTime;
            sawWheel.position += movementDirection * sawWheelSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        movementDirection *= -1;
        StartCoroutine(TrapBehaviour());
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<IDamageAble>() != null)
        {
            other.gameObject.GetComponent<IDamageAble>().TakeDmg(trapDmg);
        }
    }
}
