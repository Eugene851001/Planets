using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SphereMoveableObject : SpherePoint
{
    protected float dAzimut, dZenit;
    [SerializeField] protected float speed;

    protected int polusDirection = 1;

    public event Action<float, float> OnMove;
    public event Action<int> OnPolusChange;

    public float Speed => speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        BeforeMove();

        zenit += dZenit;
        azimut += dAzimut;

        if (zenit > 180 || zenit < 0)
        {
            zenit -= dZenit;
            azimut += 180;
            polusDirection = -polusDirection;
            OnPolusChange?.Invoke(polusDirection);
        }

        ApplyPosition();
        AfterMove();
    }

    protected virtual void ApplyPosition()
    {
        transform.position = Planet.transform.position + Utils.SphereToDecart(zenit, azimut, radius);

        OnMove?.Invoke(zenit, azimut);
    }

    protected virtual void BeforeMove()
    {

    }

    protected virtual void AfterMove()
    {

    }
}
