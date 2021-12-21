using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] Slider playerHealthBar;
    [SerializeField] GameObject player;
    BaseStats playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = player.GetComponent<BaseStats>();
        Debug.Log(player.GetComponent<BaseStats>().Health);
        SetHealthBarBaseStats();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }
    void SetHealthBarBaseStats()
    {
        
        playerHealthBar.maxValue = playerHealth.Health;
    }
    void UpdateHealthBar()
    {
        playerHealthBar.value = playerHealth.Health;
    }
}
