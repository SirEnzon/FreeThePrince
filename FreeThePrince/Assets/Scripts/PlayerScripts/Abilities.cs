using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    [Header("All Player Abiilities")]
    [SerializeField] private List<Ability> abilities;


    //TODO: - add ability

    public List<Ability> GetAllPlayerAbilities()
    {
        List<Ability> returnedAbilityList = abilities;

        return returnedAbilityList;
    }
}
