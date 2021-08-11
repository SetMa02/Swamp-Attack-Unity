using System.Collections;
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

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    
    
    private void Start()
    {
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint
            
            );
        }
    }

    public void ApplyDamage(int damage)
    {
        HealthChanged?.Invoke(_currentHealth, _health);
        _currentHealth -= damage;
        if(_currentHealth <= 0)
            Destroy(gameObject);
    }
    
    public void AddMoney(int money)
    {
        Money += money;
    }
}
