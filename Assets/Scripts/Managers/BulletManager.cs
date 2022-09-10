using Assets.Scripts;
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


    public static BulletManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void CreateBullet(GameObject shooter, float dZenit, float dAzimut)
    {
        if (shooter.TryGetComponent(out SpherePoint point) && shooter.TryGetComponent(out INamedEntity namedEntity))
        {
            var bulletObject = Instantiate(_bulletPrefab, shooter.transform);
            var bullet = bulletObject.GetComponent<Bullet>();

            bullet.InitPlanet(_planet);

            bullet.Azimut = point.Azimut + dAzimut * 5;
            bullet.Zenit = point.Zenit + dZenit * 5;

            bullet.DAzimut = dAzimut;
            bullet.DZenit = dZenit;
            bullet.Owner = namedEntity;

            bullet.OnBulletDamage += HandleBulletCollision;

            _bullets.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void HandleBulletCollision(Bullet bullet, IDamageable damageable)
    {
        _bullets.Remove(bullet);
        damageable.TakeDamage(bullet.Damage);

        Destroy(bullet.gameObject);
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
