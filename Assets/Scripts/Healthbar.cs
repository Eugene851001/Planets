using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private TextMeshProUGUI _healthText;


    public void UpdateHealth(int maxHealth, int health)
    {
        _healthbarSprite.fillAmount = health / (float)maxHealth;
        _healthText.text = $"{health} / {maxHealth}";
    }
}   
