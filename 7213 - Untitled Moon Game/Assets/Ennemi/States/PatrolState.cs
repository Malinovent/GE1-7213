using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State {
    private Vector2 patrolPoint;
    private float patrolSpeed = 5f;

    public PatrolState(EnemyController _enemy, Transform _playerTransform, Vector2 _patrolPoint, float _patrolSpeed) : base(_enemy, _playerTransform) {
        patrolPoint = _patrolPoint;
        patrolSpeed = _patrolSpeed;
    }

    public override void Tick() {
        // Patrol behavior, moving towards a point
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position, 
            patrolPoint, 
            patrolSpeed * Time.deltaTime);
    }
    
    public override void OnStateEnter()
    {
        enemy.SetAnimation("Enemy Run");
        base.OnStateEnter();
    }
}
