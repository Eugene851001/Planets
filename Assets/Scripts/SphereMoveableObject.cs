using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SphereMoveableObject : MonoBehaviour
{
    protected float azimut, zenit;
    protected float dAzimut, dZenit;

    protected int polusDirection = 1;
    protected float radius;

    public event Action<float, float> OnMove;
    public event Action<int> OnPolusChange;

    public float Azimut => azimut;
    public float Zenit => zenit;

    public GameObject Planet;


    private void Awake()
    {
        if (Planet != null)
        {
            SetRadius();
        }
    }

    public void InitPlanet(GameObject planet)
    {
        Planet = planet;
        SetRadius();
    }

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

    private void SetRadius() => 
        radius = Planet.GetComponent<SphereCollider>().radius * Planet.gameObject.transform.localScale.x;
}
