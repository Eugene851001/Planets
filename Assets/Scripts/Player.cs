using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class Player : SphereMoveableObject, INamedEntity, IDamageable
{
    [SerializeField] private float _speed = 100;

    private int maxHealth = 100;
    private int health = 100;

    private float prevZenit;
    private float prevAzimut;

    private float collisionExitSpeed = 50;
    private Vector2 collisionExitDiretion;

    private bool isCollision;

    public string Name => "Player";

    public float Zenit => zenit;
    public float Azimut => azimut;

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
            Move();
        }
        else
        {
            ExitCollision();
        }
    }

    protected override void BeforeMove()
    {
        dAzimut = polusDirection * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        dZenit = polusDirection * -Input.GetAxis("Vertical") * _speed * Time.deltaTime;

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

        Debug.Log($"Take Damage, health: {health}/{maxHealth}");
    }
}
