using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    [SerializeField] Image healthbar;
    float maxEnemyHp;
    private void Start()
    {
        maxEnemyHp = GetComponent<BaseStats>().Health;
    }
    // Start is called before the first frame update
    void Update()
    {
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        healthbar.fillAmount = GetComponent<BaseStats>().Health / maxEnemyHp;
    }
}
