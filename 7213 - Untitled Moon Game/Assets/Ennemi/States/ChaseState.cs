using UnityEngine;

public class ChaseState : State
{
    private float chaseSpeed;
    
    public ChaseState(EnemyController _enemy, Transform _playerTransform, float _chaseSpeed) : base(_enemy, _playerTransform)
    {
        chaseSpeed = _chaseSpeed;
    }

    public override void Tick()
    {
        enemy.transform.position = Vector2.MoveTowards(
            enemy.transform.position, 
            playerTransform.position, 
            chaseSpeed *  Time.deltaTime);
    }
    
    public override void OnStateEnter()
    {
        enemy.SetAnimation("Enemy Attack 1");
        base.OnStateEnter();
    }
}