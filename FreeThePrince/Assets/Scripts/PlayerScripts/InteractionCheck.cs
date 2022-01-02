using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionCheck : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI interactableText;
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
        if (Physics.Raycast(ray, out hitInfo,checkLength,interactableLayer))
        {
            interactableText.gameObject.SetActive(true);
            interactableText.text = hitInfo.collider.gameObject.GetComponent<InteractableObject>().InteractionText;
            if (Input.GetKeyDown(KeyCode.E))
            {
                IInteractable interactableObject = hitInfo.collider.gameObject.GetComponent<IInteractable>();
                interactableObject.OnInteraction();
            }
        }
        else
        {
            interactableText.gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawRay(ray);
    }
}
