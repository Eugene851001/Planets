using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System;

public class Bullet : SphereMoveableObject
{ 
    [SerializeField] protected int damage;

    public float Zenit { set => zenit = value; }
    public float Azimut {  set => azimut = value; }

    public float DZenit { get => dZenit; set => dZenit = GetDistance(value); }
    public float DAzimut { get => dAzimut; set => dAzimut = GetDistance(value); }

    public int Damage => damage;

    public INamedEntity Owner;

    public event Action<Bullet, IDamageable> OnBulletDamage;
    
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

        if (damageable != default(IDamageable) && damageable != Owner)
        {
            OnBulletDamage?.Invoke(this, damageable);
        }
    }

    void HandleChangePolus(int polusDir) => dZenit = -dZenit;

    private float GetDistance(float projection) => projection * speed * Time.deltaTime; 
}
