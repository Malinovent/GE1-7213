using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected EnemyController enemy;
    protected Transform playerTransform;

    public State(EnemyController _enemy, Transform _playerTransform) {
        enemy = _enemy;
        playerTransform = _playerTransform;
    }

    public abstract void Tick();
    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }
}

