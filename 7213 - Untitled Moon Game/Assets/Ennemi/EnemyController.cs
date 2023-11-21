using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private StateMachine stateMachine;
    Animator animator;
    public Transform playerTransform;
    public Vector2 patrolPoint;
    
    [Header("Chase Parameters")]
    public float chaseSpeed = 5f;
    
    [Header("Patrol Parameters")]
    public float patrolSpeed = 5f;


    void Start() {
        animator = GetComponent<Animator>();
        stateMachine = new StateMachine();
        stateMachine.SetState(new IdleState(this, playerTransform));

        patrolPoint = this.transform.position;
        
    }

    void Update() {
        stateMachine.Tick();

        switch (stateMachine.currentState )
        {
            case ChaseState:
                CheckForPatrol();
                break;
            case PatrolState:
                CheckForIdle();
                CheckForChase();
                break;
            case IdleState:
                CheckForChase();
                break;
        }
    }

    private void CheckForPatrol()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > 10) 
        {
            stateMachine.SetState(new PatrolState(this, playerTransform, patrolPoint, patrolSpeed));
        }
    }

    private void CheckForIdle()
    {
        if (Vector2.Distance(transform.position, patrolPoint) < 0.1f) 
        {
            stateMachine.SetState(new IdleState(this, playerTransform));
        }
    }
    
    private void CheckForChase() 
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < 5f) 
        {
            stateMachine.SetState(new ChaseState(this, playerTransform, chaseSpeed));
        }
    }
    
    public State GetCurrentState() 
    {
        return stateMachine.currentState;
    }

    public void SetAnimation(string animationState)
    {
        animator.Play(animationState);
    }
}
