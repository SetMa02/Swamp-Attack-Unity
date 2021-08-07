using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _targetState;

    protected Player Target { get; private set; }

    public bool TargetState => _targetState;

    protected bool NeedTransit { get; private set; }

    public void Init(Player target)
    {
        Target = target;
        
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }
}
