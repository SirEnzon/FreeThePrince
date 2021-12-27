using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    [SerializeField] HingeJoint doorJoint;
    JointLimits limits;
    // Start is called before the first frame update
    void Start()
    {  
        limits = doorJoint.limits;
        limits.min = 0;
        limits.max = 0;
        doorJoint.limits = limits;
    }
    public void CheckIfLeverHasBeenPulled()
    {
            limits.min = -90;
            limits.max = 90;
            doorJoint.limits = limits;
    }
}
