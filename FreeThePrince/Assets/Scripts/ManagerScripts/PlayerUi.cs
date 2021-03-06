using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] Slider playerHealthBar;
    [SerializeField] Slider staminaBar;
    [SerializeField] GameObject player;
    Coroutine goRoutine;
    SpecialPlayerStats playerStats;
    void Start()
    {
        playerStats = player.GetComponent<SpecialPlayerStats>(); 
        SetBarBaseStats();    
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        UpdateStaminaBar();
    }
    void SetBarBaseStats()
    {
        staminaBar.maxValue = playerStats.Stamina;
        playerHealthBar.maxValue = playerStats.Health;
    }
    void UpdateHealthBar()
    {
        playerHealthBar.value = playerStats.Health;
    }
    void UpdateStaminaBar()
    {     
            staminaBar.value = playerStats.Stamina;  
    }
  
}
