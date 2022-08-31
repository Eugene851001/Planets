using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int lastShootTime;
    [SerializeField] private int shootInterval;
    [SerializeField] private GameObject _planet;
    [SerializeField] private GameObject _bulletPrefab;

    private List<Bullet> _bullets = new List<Bullet>();

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.Run && Input.GetMouseButton(0))
        {
            int currentTime = Environment.TickCount;
            if (currentTime - lastShootTime > shootInterval)
            {
                lastShootTime = currentTime;

                var playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
                var mousePos = Input.mousePosition;
                var dir = (mousePos - playerPos).normalized;
                float dZenit = -dir.y;
                float dAzimit = dir.x;

                var bulletObject = Instantiate(_bulletPrefab, player.transform);
                var bullet = bulletObject.GetComponent<Bullet>();

                bullet.InitPlanet(_planet);

                bullet.Azimut = player.Azimut + dAzimit * 5;
                bullet.Zenit = player.Zenit + player.PolusDirection * dZenit * 5;

                bullet.DAzimut = dAzimit;
                bullet.DZenit = dZenit;
                bullet.Owner = player;
                
                _bullets.Add(bullet);
            }
        }
    }

    public void Reset()
    {
        foreach(var bullet in _bullets)
        {
            Destroy(bullet);
        }

        _bullets.Clear();
    }
}
