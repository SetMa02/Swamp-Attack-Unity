using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemies : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
     private Player _target;

     public int Reward => _reward;
     
    public Player Target => _target;
    public event UnityAction<Enemies> Dieing;

    public void Init(Player target)
    {
        _target = target; 
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= damage)
        {
            Dieing?.Invoke(this);
            Destroy(gameObject);
        }
            
    }
}
