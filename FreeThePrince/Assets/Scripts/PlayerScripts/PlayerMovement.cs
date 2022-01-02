using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] LayerMask wallLayer;
    float xInputValue;
    float zInputValue;
    static bool isWalking;
    static public bool IsWalking { get { return isWalking; } set { isWalking = value; } }
    Vector3 movement;
    Rigidbody playerRb;
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerMovementInput();
    }
    void PlayerMovementInput()
    {
        zInputValue = Input.GetAxis("Vertical");
        xInputValue = Input.GetAxis("Horizontal");
        movement = new Vector3(xInputValue, 0, zInputValue);
        if(!Physics.Raycast(transform.position, transform.forward, 2f, wallLayer) && !Input.GetMouseButton(0) && !Dash.IsDashing)
        {
            transform.position += movement.normalized * GetComponent<BaseStats>().Speed * Time.deltaTime;
        }
        else
        {
            playerRb.velocity = Vector3.zero;
        }
        Debug.DrawRay(transform.position,transform.forward * 2,Color.black);
      
        if (movement != Vector3.zero && !Input.GetMouseButton(0))
        {
            isWalking = true;
            transform.rotation = Quaternion.LookRotation(movement);
        }
        else
        {
            isWalking = false;
        }

       
    }
}
