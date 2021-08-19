﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    
    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private int _currentWeaponIndex;
    private Animator _animator;
    
    
    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponIndex]);
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }
    
    private void Update()
    {
        if (_currentWeapon.Label == "ПП" && Input.GetMouseButton(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
            
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
        
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);
        if(_currentHealth <= 0)
            Destroy(gameObject);
    }
    
    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
        MoneyChanged?.Invoke(Money);
    }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
        {
            _currentWeaponIndex = 0;
        }
        else
            _currentWeaponIndex++;
        
        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    public void PrewiousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Capacity - 1;
        else
            _currentWeaponIndex--;
        
        ChangeWeapon(_weapons[_currentWeaponIndex]);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
}
