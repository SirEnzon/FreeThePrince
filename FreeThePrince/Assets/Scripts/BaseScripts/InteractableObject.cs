using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour,IInteractable
{
    [SerializeField] protected string interActionText;
    public string InteractionText { get { return interActionText; } private set { } }
    public virtual void OnInteraction()
    {
       //InteractionSound 
       //PArticles
       //Animation
    }
}
