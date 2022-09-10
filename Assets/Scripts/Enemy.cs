using Assets.Scripts;
using Assets.Scripts.Behaviour;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : SphereMoveableObject, IDamageable, INamedEntity
{
    public float DZenit { get => dZenit; set => dZenit = GetDistance(value); }
    public float DAzimut { get => dAzimut; set => dAzimut = GetDistance(value); }

    //in degrees
    public float FollowRange = 45;
    public float AttackRange = 10;

    public virtual string Name => "Bandit";

    public Player Player;

    [SerializeField] private Healthbar healthbar;
    private int damage = 20;

    private int attackInterval = 1000;
    private int lastAttackTime;

    private int maxHealth = 100;
    private int health = 100;

    private IThinker state;
    private ILogger _logger;

    private void Awake() => InitState();

    protected void InitState()
    {
        Player = FindObjectOfType<Player>();
        state = new Patrolling(Player);
        state.Context = this;

        InitPlanet(PlanetsManager.Instance.ActivePlanet);
    }

    void Start()
    {
        _logger = LoggerFactory.Instance?.GetLogger();
        PlanetsManager.OnPlanetChanged += HandleChangePlanet;
    }

    private void OnDestroy()
    {
        PlanetsManager.OnPlanetChanged -= HandleChangePlanet;
    }

    public void InitLocation(float zenit, float azimut)
    {
        this.zenit = zenit;
        this.azimut = azimut;
    }

    // Update is called once per frame
    void Update()
    {
        state.Think();
        Move();
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

        _logger?.Log($"{Name} took {damage} damage");
        healthbar?.UpdateHealth(maxHealth, health);
        if (health == 0)
        {
            _logger?.Log($"{Name} died");
            Destroy(gameObject);
        }
    }

    public virtual void Attack(IDamageable damageable)
    {
        int currentTime = Environment.TickCount;

        if (currentTime - lastAttackTime > attackInterval)
        {
            lastAttackTime = currentTime;

            HelpAttack(Player, damageable);
        }
    }

    protected virtual void HelpAttack(SpherePoint target, IDamageable damageable)
    {
        damageable.TakeDamage(damage);
        _logger?.Log($"{Name} attacks with {damage} demage");
    }

    public void ChangeState(IThinker newState)
    {
        state = newState;
    }

    private void HandleChangePlanet(GameObject oldPlanet, GameObject newPlanet)
    {
        if (newPlanet != this.Planet)
        {
            ChangeState(new Freeze());
        }
        else
        {
            ChangeState(new Patrolling(Player));
        }
    }
}
