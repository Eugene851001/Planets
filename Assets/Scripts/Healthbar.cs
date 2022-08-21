using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;
    [SerializeField] private TextMeshProUGUI _healthText;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;    
    }

    public void UpdateHealth(int maxHealth, int health)
    {
        _healthbarSprite.fillAmount = health / (float)maxHealth;
        _healthText.text = $"{health} / {maxHealth}";
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(this.transform.position - _camera.transform.position);
    }
}
