using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] Vector3 cameraOffset;
    

        void Update()
        {
            FollowPlayer();

        }
        void FollowPlayer()
        {
            transform.position = targetToFollow.position + cameraOffset;
        }
    
}
