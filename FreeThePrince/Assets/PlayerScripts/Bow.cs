using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bow : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private string fireButton;
    // [SerializeField] private float prefabImpulse = 100f;


    [Header("Cooldown")]
    [SerializeField] private float timeBetweenShots = 0f;

    // fire Mouse Pos
    [Header("Fire Direction - Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        AimToMousePos();


        timeBetweenShots -= Time.deltaTime;

        if (Input.GetButton(fireButton))
        {
            if (timeBetweenShots < 0)
            {

                FireBow();
            }

        }

        // Debug.Log(fireCooldown);
    }

    private void FireBow()
    {
        if (timeBetweenShots <= 0f)
        {
           Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
           timeBetweenShots = 0.5f;
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
