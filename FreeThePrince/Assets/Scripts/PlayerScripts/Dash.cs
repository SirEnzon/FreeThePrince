using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float dashForce;
    static float dashCD;
    static public float DashCd { get { return dashCD; } }
    static bool dashIsAvailable;
    static public bool DashIsAvailable { get { return dashIsAvailable; } }
    static bool isDashing;
    static public bool IsDashing { get { return isDashing; } set { isDashing = value;} }

    SpecialPlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<SpecialPlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDash();
        MakeDashAvailableAgain();
    }
    void PlayerDash()
    {
       
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCD <= 0 && playerStats.Stamina >= 10)
        {
            playerStats.Stamina -= 10;
            StartCoroutine(DashInvincibility(1));
            
            
        }
        else if(!isDashing)
        {
            dashCD -= Time.deltaTime;
            playerStats.Stamina += 0.01f;
        }
    }
    IEnumerator DashInvincibility(float dashInvincibility)
    {
        
        while(dashInvincibility >= 0)
        {
            dashIsAvailable = false;
            isDashing = true;
            playerTransform.position += transform.forward * dashForce * Time.deltaTime;
            dashInvincibility -= Time.deltaTime;
            GetComponent<BaseStats>().IsInvincible = true;
            yield return new WaitForEndOfFrame();

        }
        isDashing = false;
        dashCD = 1;
        dashInvincibility = 1;
        GetComponent<BaseStats>().IsInvincible = false;
    }
    void MakeDashAvailableAgain()
    {
        if(playerStats.Stamina > 10 && !isDashing)
        {
            dashIsAvailable = true;
        }
    }
}
