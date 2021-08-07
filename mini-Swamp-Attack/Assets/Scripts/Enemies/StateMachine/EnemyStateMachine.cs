using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemies))]
public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private Player _target;
    private State _currentState;

   public State Current => _currentState;

   private void Start()
   {
       _target = GetComponent<Enemies>().Target;
   }

   private void Reset(State startState)
   {
       _currentState = startState;
       
       if(_currentState != null)
           _currentState.Enter(_target);
   }

   private void Update()
   {
       if(_currentState == null)
           return;
       
   }
}
