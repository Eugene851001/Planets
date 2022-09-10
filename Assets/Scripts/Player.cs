using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class Player : SphereMoveableObject, INamedEntity, IDamageable
{
    //TODO: move to another class (PlayerManager or Destructable object)
    [SerializeField] private Healthbar _healthbar;

    private int shootInterval = 1000;
    private int lastShootTime;

    private int maxHealth = 100;
    private int health = 100;

    private float prevZenit;
    private float prevAzimut;

    private float collisionExitSpeed = 50;
    private Vector2 collisionExitDiretion;

    private bool isCollision;

    private ILogger _logger;

    public string Name => "Player";

    public int PolusDirection => polusDirection;

    private void Awake()
    {
        speed = 10;
        _logger = LoggerFactory.Instance.GetLogger();
        PlanetsManager.OnPlanetChanged += HandlePlanetChange;

        var planet = PlanetsManager.Instance.ActivePlanet;
        InitPlanet(planet);
    }

    public void OnObjectCollision(GameObject other)
    {
        isCollision = true;

        float deltaAzimut = (prevAzimut - azimut);
        float deltaZenit = (prevZenit - zenit);

        collisionExitDiretion = new Vector2(deltaZenit, deltaAzimut).normalized;
    }

    public void OnObjectCollisionExit()
    {
        isCollision = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        zenit = 30;
        azimut = 10;
    }

    // Update is  called once per frame
    void Update()
    {
        if (!isCollision)
        {
            if (Input.GetKey(KeyCode.P))
            {
                var planetName = PlanetsManager.Instance.ActivePlanetName == Constants.Planets.Earth
                    ? Constants.Planets.Mars : Constants.Planets.Earth;
                PlanetsManager.Instance.ChangePlanet(planetName);
            }
            else if (GameManager.Instance.State == GameState.Run && Input.GetMouseButton(0))
            {
                HandleShoot();
            }

            Move();
            //Debug.Log($"Player position: {Zenit}:{Azimut}");
        }
        else
        {
            ExitCollision();
        }
    }

    protected override void BeforeMove()
    {
        dAzimut = polusDirection * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        dZenit = polusDirection * -Input.GetAxis("Vertical") * speed * Time.deltaTime;

        prevZenit = zenit;
        prevAzimut = azimut;
    }

    private void ExitCollision()
    {
        zenit += collisionExitDiretion.x * collisionExitSpeed * Time.deltaTime;
        azimut += collisionExitDiretion.y * collisionExitSpeed * Time.deltaTime;

        ApplyPosition();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            GameManager.Instance.UpdateState(GameState.GameOver);
        }

        _healthbar.UpdateHealth(health, maxHealth);
        _logger.Log($"Take Damage, health: {health}/{maxHealth}");
    }

    private void HandlePlanetChange(GameObject oldPlanet, GameObject newPlanet)
    {
        InitPlanet(newPlanet);
    }

    private void HandleShoot()
    {
        int currentTime = Environment.TickCount;
        if (currentTime - lastShootTime > shootInterval)
        {
            lastShootTime = currentTime;

            var playerPos = Camera.main.WorldToScreenPoint(transform.position);
            var mousePos = Input.mousePosition;
            var dir = (mousePos - playerPos).normalized;
            float dZenit = PolusDirection * -dir.y;
            float dAzimut = PolusDirection * dir.x;

            BulletManager.Instance.CreateBullet(this.gameObject, dZenit, dAzimut);
        }
    }
}
