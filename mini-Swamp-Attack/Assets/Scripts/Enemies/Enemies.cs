using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class Enemies : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    [SerializeField] private Player _target;

    public Player Target => _target;
    public event UnityAction Dieing;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if(_health <= damage)
            Destroy(gameObject);
    }
}
