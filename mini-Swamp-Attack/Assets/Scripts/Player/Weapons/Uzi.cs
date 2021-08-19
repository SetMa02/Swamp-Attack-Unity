using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] private float _delay = 0.5f;

    private float _lastAttackTime;
    public override void Shoot(Transform shootPoint)
    {
        if (_lastAttackTime <= 0)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            _lastAttackTime = _delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
}
