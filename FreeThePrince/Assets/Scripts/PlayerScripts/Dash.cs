using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float dashForce;
    [SerializeField] float dashCD;
    static bool isDashing;
    static public bool IsDashing { get { return isDashing; } set { isDashing = value;} }

    SpecialPlayerStats playerStats;
    Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<SpecialPlayerStats>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDash();
    }
    void PlayerDash()
    {
        dashCD -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCD <= 0 && playerStats.Stamina >= 10)
        {
            playerStats.Stamina -= 10;
            StartCoroutine(DashInvincibility(1));
            dashCD = 1;
            playerRb.AddForce(playerTransform.forward * dashForce, ForceMode.Impulse);
        }
        else
        {
            playerStats.Stamina += 0.01f;
        }
    }
    IEnumerator DashInvincibility(float dashInvincibility)
    {
        while(dashInvincibility >= 0)
        {
            dashInvincibility -= Time.deltaTime;
            GetComponent<BaseStats>().IsInvincible = true;
            yield return new WaitForEndOfFrame();
        }
        dashInvincibility = 1;
        GetComponent<BaseStats>().IsInvincible = false;
        Debug.Log(GetComponent<BaseStats>().IsInvincible);

    }
}
