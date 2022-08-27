using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Bullet : SphereMoveableObject
{
    [SerializeField] protected float speed;
    [SerializeField] protected float damage;

    public float Zenit { get => zenit; set => zenit = value; }
    public float Azimut { get => azimut; set => azimut = value; }

    public float DZenit { get => dZenit; set => dZenit = GetDistance(value); }
    public float DAzimut { get => dAzimut; set => dAzimut = GetDistance(value); }

    public INamedEntity Owner;
    
    // Start is called before the first frame update
    void Start()
    {
        OnPolusChange += HandleChangePolus;
    }

    private void OnDestroy()
    {
        OnPolusChange -= HandleChangePolus;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();  

        if (damageable != default(IDamageable))
        {
            damageable.TakeDamage((int)damage);
        }

        Destroy(this.gameObject);
    }

    void HandleChangePolus(int polusDir) => dZenit = -dZenit;

    private float GetDistance(float projection) => projection * speed * Time.deltaTime; 
}
