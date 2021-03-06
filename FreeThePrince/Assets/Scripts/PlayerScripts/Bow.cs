using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bow : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform leftSpawnPoint;
    [SerializeField] private Transform centerSpawnPoint;
    [SerializeField] private Transform rightSpawnPoint;
    [SerializeField] private string fireButton;
    [SerializeField] private string secondaryFireButton = "Fire2";
    [Header("Cooldown")]
    [SerializeField] private float timeBetweenShots = 0f;

    // fire Mouse Pos
    [Header("Fire Direction - Camera")]
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;

    // Abilities 
    private Abilities abilities;
    private List<Ability> playerAbilityList;
    private SpecialArrowShot secondaryFireMode;

    private void Start()
    {
        abilities = gameObject.GetComponentInParent<Abilities>();
        playerAbilityList = abilities.GetAllPlayerAbilities();
        if (playerAbilityList != null)
        {
            secondaryFireMode = playerAbilityList[0].GetComponent<SpecialArrowShot>();
        }
        else
        {
            Debug.LogWarning("No Abilities in List found");
        }
    }


    private void Update()
    {
        AimToMousePos();
        timeBetweenShots -= Time.deltaTime;

        if (Input.GetButton(fireButton) && timeBetweenShots <= 0)
        {
                FireBow();
        }

        if (Input.GetButtonDown(secondaryFireButton))
        {
            if (timeBetweenShots < 0)
            {    
                secondaryFireMode.Init(leftSpawnPoint, centerSpawnPoint, rightSpawnPoint);
            }
        }

        // Debug.Log(fireCooldown);
    }

    private void FireBow()
    {
        Instantiate(projectilePrefab,centerSpawnPoint.position, centerSpawnPoint.rotation);
        timeBetweenShots = 1.5f;
    }

    private void FireSpecialShot()
    {
        
    }

    protected void AimToMousePos()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float rayDistance = 10f;

        if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask) && Input.GetMouseButton(0))
        {
            Vector3 hitPoint = hit.point;

            hitPoint.y = playerTransform.position.y;
            centerSpawnPoint. transform.LookAt(hitPoint);
            playerTransform.LookAt(hitPoint);

            Debug.DrawRay(playerTransform.position, centerSpawnPoint.forward * rayDistance, Color.green);
        }
    }

}
