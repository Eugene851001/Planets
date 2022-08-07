using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action<float, float> OnMove;

    public GameObject Planet;

    [SerializeField] private float _distance = 6;
    [SerializeField] private float _speed = 100;

    private float azimut;
    private float zenit;


    private float prevZenit;
    private float prevAzimut;

    private float collisionExitSpeed = 50;
    private Vector2 collisionExitDiretion;

    private bool isCollision;

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

    // Update is called once per frame
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

    private void Move()
    {
        float dAzimut = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float dZenit = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        prevZenit = zenit;
        prevAzimut = azimut;

        zenit += dZenit;
        azimut += dAzimut;

        //this.transform.LookAt(_planet.transform.position);

        ApplyPosition();
    }

    private void ApplyPosition()
    {
        transform.position = Planet.transform.position + Utils.SphereToDecart(zenit, azimut, _distance);

        OnMove?.Invoke(zenit, azimut);
    }

    private void ExitCollision()
    {
        zenit += collisionExitDiretion.x * collisionExitSpeed * Time.deltaTime;
        azimut += collisionExitDiretion.y * collisionExitSpeed * Time.deltaTime;

        ApplyPosition();
    }
}
