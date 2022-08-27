using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestructableObject : InteractableObject
{
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private GameObject dropedItemPrefab;

    public int MaxHealth = 100;
    public int Health = 100;

    private void Awake()
    {
        Key = KeyCode.E;
    }

    private void Start()
    {
        healthbar.UpdateHealth(MaxHealth, Health);
    }

    protected override void Interact()
    {
        if (Health > 0)
        {
            Health -= 20;

            if (Health <= 0)
            {
                Destroy(gameObject);
                if (dropedItemPrefab != null)
                {
                    Instantiate(dropedItemPrefab, transform.position, transform.rotation);
                }
            }
            else
            {
                healthbar.UpdateHealth(MaxHealth, Health);

                Debug.Log($"Health: {Health}/{MaxHealth}");
            }
        }
    }
}
