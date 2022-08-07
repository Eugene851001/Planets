using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance = 15;

    private GameObject _planet;

    // Start is called before the first frame update
    void Start()
    {
        _planet = _player.Planet;
        _player.OnMove += HandleMove;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void HandleMove(float zenit, float azimut)
    {
        this.transform.LookAt(_planet.transform.position);
        
        this.transform.position = _planet.transform.position + Utils.SphereToDecart(zenit, azimut, _distance);
    }
}