using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Slider healthBar;
    public Health playerHealth;
    public static HealthBarPlayer instance;
    private void OnEnable()
    {
        instance = this;
    }
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Bullet").GetComponent<Health>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.value = playerHealth.maxHealth;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
