using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellOfWellBeing : InteractableObject
{
    [SerializeField] SpecialPlayerStats playerStats;
    public override void OnInteraction()
    {
        base.OnInteraction();
        playerStats.Health += 40;
        playerStats.Stamina += 40;
    }
}
