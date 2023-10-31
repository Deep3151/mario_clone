using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{

    [SerializeField] private Image _healthbarSprite;

    public void updateHealthBar(float maxHealth, float currentHealth )
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
    
}
