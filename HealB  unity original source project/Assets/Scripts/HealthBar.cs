using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar: MonoBehaviour
{
    [SerializeField] private Image foreground;
    public Text HealthLevel;

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        float healthPercentage = currentHealth / maxHealth;
        foreground.fillAmount = healthPercentage;
        HealthLevel.text = currentHealth.ToString();
    }

}
