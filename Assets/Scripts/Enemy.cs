using Assets.Scripts;
using Assets.Scripts.Behaviour;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SphereMoveableObject, IDamageable, INamedEntity
{
    public float DZenit { get => dZenit; set => dZenit = GetDistance(value); }
    public float DAzimut { get => dAzimut; set => dAzimut = value; }

    //in degrees
    public float FollowRange = 45;
    public float AttackRange = 10;

    public string Name => "Bandit";

    public Player Player;

    private int damage = 20;

    private int attackInterval = 1000;
    private int lastAttackTime;

    private float speed = 5;

    private float health = 100;

    private IThinker state;

    private void Awake()
    {
        Player = FindObjectOfType<Player>();
        state = new Patrolling(Player);
        state.Context = this;
    }

    public void InitLocation(float zenit, float azimut)
    {
        this.zenit = zenit;
        this.azimut = azimut;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        state.Think();
        Move();
        Debug.Log($"Enemy position: {Zenit}:{Azimut}");
    }

    public void SetDestination(float zenit, float azimut)
    {
        var dir = (new Vector2(zenit, azimut) - new Vector2(this.zenit, this.azimut)).normalized;

        dZenit = dir.x * speed * Time.deltaTime;
        dAzimut = dir.y * speed * Time.deltaTime;
    }

    private float GetDistance(float projection) => projection * speed * Time.deltaTime;

    public void TakeDamage(int damage)
    {
        health -= damage;

        Debug.Log($"{Name} took damage");
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack(IDamageable damageable)
    {
        int currentTime = Environment.TickCount;

        if (currentTime - lastAttackTime > attackInterval)
        {
            lastAttackTime = currentTime;
            
            damageable.TakeDamage(damage);
            Debug.Log($"{Name} attack {damage}");
        }
    }

    public void ChangeState(IThinker newState)
    {
        state = newState;
    }
}
