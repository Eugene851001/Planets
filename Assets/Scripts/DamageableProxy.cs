using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableProxy : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject source;

    public void TakeDamage(int damage)
    {
        if (source.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }
    }
}
