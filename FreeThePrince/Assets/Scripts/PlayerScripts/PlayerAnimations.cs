using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator playerAnimations;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        ActivateRunAnimation();
        ActivateAttackAnimation();
        ActivateRoleAnimation();
    }
    void ActivateRunAnimation()
    {
        if(PlayerMovement.IsWalking && !Input.GetMouseButton(0))
        {
            playerAnimations.SetBool("IsRunning", true);
        }
        else
        {
            playerAnimations.SetBool("IsRunning", false);
        }
    }
    void ActivateAttackAnimation()
    {
        if (Input.GetMouseButton(0) && !Dash.IsDashing)
        {
            playerAnimations.SetBool("IsAttacking", true);
        }
        else
        {
            playerAnimations.SetBool("IsAttacking", false);
        }
    }
    void ActivateRoleAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Dash.DashIsAvailable)
        {
            playerAnimations.SetBool("IsRolling" ,true);
            Debug.Log("Hello");
        }
        else 
        {
            playerAnimations.SetBool("IsRolling", false);
        }
        
    }
}
