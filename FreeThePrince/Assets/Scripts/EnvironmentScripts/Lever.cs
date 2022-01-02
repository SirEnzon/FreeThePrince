using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractableObject
{
    GameObject[] firstRoomDoors;
    
    public override void OnInteraction()
    {
        if(firstRoomDoors == null)
        {
            firstRoomDoors = GameObject.FindGameObjectsWithTag("FirstRoom");
        }
        Debug.Log(firstRoomDoors.Length);

        foreach (GameObject bigDoor in firstRoomDoors)
        {
            bigDoor.GetComponent<RoomDoor>().CheckIfLeverHasBeenPulled();
           
        }

    }
}
