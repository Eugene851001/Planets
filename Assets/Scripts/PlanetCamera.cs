using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _distance = 15;

    private int UpDirection = 1;
    private GameObject _planet;

    // Start is called before the first frame update
    void Start()
    {
        _planet = _player.Planet;
        _player.OnMove += HandleMove;
        _player.OnPolusChange += HandlePolusChange;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void HandleMove(float zenit, float azimut)
    {
        this.transform.LookAt(_planet.transform.position, new Vector3(0, UpDirection, 0));
        
        this.transform.position = _planet.transform.position + Utils.SphereToDecart(zenit, azimut, _distance);
    }

    private void HandlePolusChange(int polusDirection)
    {
        UpDirection = -UpDirection;
    }
}
