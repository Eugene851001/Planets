using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public override string Name => "Shooter enemy";

    protected override void HelpAttack(SpherePoint target, IDamageable damageable)
    {
        var dir = new Vector2(target.Zenit - Zenit, target.Azimut - Azimut).normalized;
        BulletManager.Instance.CreateBullet(this.gameObject, dir.x, dir.y);
    }

    private void Awake()
    {
        AttackRange = 30;
    }
}
