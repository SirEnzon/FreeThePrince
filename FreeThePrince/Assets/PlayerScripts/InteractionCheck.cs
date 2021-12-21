using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCheck : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] float checkLength;
    Ray ray;
    RaycastHit hitInfo;
    void Update()
    {
        CheckForInteractables();
    }
    void CheckForInteractables()
    {
        ray = new Ray(playerTransform.position,playerTransform.forward * checkLength);
        if (Physics.Raycast(ray, out hitInfo,checkLength,interactableLayer) && Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactableObject = hitInfo.collider.gameObject.GetComponent<IInteractable>();
            interactableObject.OnInteraction();
            Debug.Log("HELLLLLOO");
        }
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawRay(ray);
    }
}
