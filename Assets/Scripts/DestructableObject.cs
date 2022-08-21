using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : InteractableObject
{
    public int MaxHealth = 100;
    public int Health = 100;

    private void Awake()
    {
        Key = KeyCode.E;
    }

    protected override void Interact()
    {
        if (Health > 0)
        {
            Health -= 20;
            Debug.Log($"Health: {Health}/{MaxHealth}");
        }
    }
}
