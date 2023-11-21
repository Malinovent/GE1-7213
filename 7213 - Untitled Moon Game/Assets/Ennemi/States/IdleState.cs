using UnityEngine;

public class IdleState : State {
    public IdleState(EnemyController _enemy, Transform _playerTransform) 
        : base(_enemy, _playerTransform) {}

    public override void Tick() {
        // Idle behavior, like looking around
    }

    public override void OnStateEnter()
    {
        enemy.SetAnimation("Enemy Idle");
        base.OnStateEnter();
    }
}



