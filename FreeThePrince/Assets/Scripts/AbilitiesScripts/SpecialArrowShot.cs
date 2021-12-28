using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialArrowShot : Ability
{
    // [Header("Left and Right Arrow Pos - with Offset")]
    // [SerializeField] private Transform leftSpawnPosition;
    // [SerializeField] private Transform centerSpawnPosition;
    // [SerializeField] private Transform rightSpawnPosition;

    [Range(-2f, 2f)]
    [SerializeField] private float xPosOffset = 0.25f;
    [SerializeField] private float yRotationOffset = 15f;



    // private void Start()
    // {
    //     GetXPosOffset();
    //     SetYRotationOffset();
    // }

    public void Init(Transform _leftSpawnPoint, Transform _centerSpawnPoint, Transform _rightSpawnPoint)
    {
        Instantiate(arrowPrefab, _leftSpawnPoint.position, _leftSpawnPoint.rotation);
        Instantiate(arrowPrefab, _centerSpawnPoint.position, _centerSpawnPoint.rotation);
        Instantiate(arrowPrefab, _rightSpawnPoint.position, _rightSpawnPoint.rotation);
    }

    // private void GetXPosOffset()
    // {
    //     Vector3 newPos = leftSpawnPosition.position;
    //     newPos.x = newPos.x - xPosOffset;
    //     leftSpawnPosition.position = newPos;

    //     Vector3 rightNewPos = rightSpawnPosition.position;
    //     rightNewPos.x = rightNewPos.x + xPosOffset;
    //     rightSpawnPosition.position = rightNewPos;
    // }

    // private void SetYRotationOffset()
    // {
    //     // left Rotation offset
    //     Quaternion leftRotation = leftSpawnPosition.rotation;
    //     leftRotation.eulerAngles = new Vector3(0, -yRotationOffset, 0);
    //     leftSpawnPosition.rotation = leftRotation;

    //     // right Rotation offset
    //     Quaternion rightRotation = rightSpawnPosition.rotation;
    //     rightRotation.eulerAngles = new Vector3(0, yRotationOffset, 0);
    //     rightSpawnPosition.rotation = rightRotation;
    // }
}
