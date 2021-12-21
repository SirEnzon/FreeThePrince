using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bow : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private Arrow projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private string fireButton;
    // [SerializeField] private float prefabImpulse = 100f;


    [Header("Cooldown")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float cooldown = 3f;
    [SerializeField] private float fireCooldown = 0f;
    private float lastAttackTime;

    // fire Mouse Pos
    [Header("Fire Direction - Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        AimToMousePos();


        fireCooldown -= Time.deltaTime;

        if (Input.GetButtonDown(fireButton))
        {
            if (Time.time - lastAttackTime > cooldown)
            {

                FireBow();
            }

        }

        // Debug.Log(fireCooldown);
    }

    private void FireBow()
    {
        if (fireCooldown <= 0f)
        {
            Arrow arrow = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
            arrow.Init();

            fireCooldown = 1f / fireRate;
            lastAttackTime = Time.time;
        }
    }

    protected void AimToMousePos()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float rayDistance = 10f;

        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
        {
            Vector3 hitPoint = hit.point;

            hitPoint.y = transform.transform.position.y;


            transform.LookAt(hitPoint);

            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.green);
        }
    }

}
