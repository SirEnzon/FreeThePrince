using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float xInputValue;
    float zInputValue;
    static bool isWalking;
    static public bool IsWalking { get { return isWalking; } set { isWalking = value; } }
    Vector3 movement;
    void Update()
    {
        PlayerMovementInput();
    }
    void PlayerMovementInput()
    {
        zInputValue = Input.GetAxis("Vertical");
        xInputValue = Input.GetAxis("Horizontal");
        movement = new Vector3(xInputValue, 0, zInputValue);

        transform.position += movement.normalized * GetComponent<BaseStats>().Speed * Time.deltaTime;
        if (movement != Vector3.zero)
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
