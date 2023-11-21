using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiFSM : MonoBehaviour
{
    [SerializeField] Transform player;
    Animator animator;

    [Header("Attack Parameters")]
    [SerializeField] private float AttackDist;
    [SerializeField] private float AttackSpeed;

    [Header("Chase Parameters")]
    [SerializeField] private float ChaseDist;
    [SerializeField] private float ChaseSpeed;

    [Header("Patrol Parameters")]
    [SerializeField] private float PatrolDist;
    [SerializeField] private float PatrolSpeed;
    private Vector2 startingPoint;

    //Etat: IDLE, PATROL, CHASE, ATTACK
    private EnemyState currentState = EnemyState.IDLE;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startingPoint = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case EnemyState.IDLE:
                Idle();
                break;
            case EnemyState.PATROL:
                Patrol();
                break;
            case EnemyState.CHASE:
                Chase();
                break;
            case EnemyState.ATTACK:
                Attack();
                break;
        }
    }

    public EnemyState GetState()
    {
        return currentState;
    }

    private void TransitionTo(EnemyState nextState)
    {
        switch (nextState)
        {
            case EnemyState.IDLE:
                animator.Play("IDLE");
                currentState = EnemyState.IDLE;
                break;

            case EnemyState.PATROL:
                animator.Play("IDLE");
                currentState = EnemyState.PATROL;
                break;

            case EnemyState.CHASE:
                animator.Play("ATTACK");
                currentState = EnemyState.CHASE;
                break;

            case EnemyState.ATTACK:
                animator.Play("ATTACK");
                currentState = EnemyState.ATTACK;
                break;
        }
    }

    private void Idle()
    {
        float dist = Vector2.Distance(this.transform.position, player.position);

        if(dist < ChaseDist)
        {
            //currentState = EnemyState.CHASE;
            TransitionTo(EnemyState.CHASE);
        }
    }

    private void Patrol()
    {
        float dist = Vector2.Distance(this.transform.position, startingPoint);

        this.transform.position = Vector2.MoveTowards(this.transform.position, startingPoint, PatrolSpeed * Time.deltaTime);
        
        if (dist <= 0.1f)
        {
            //currentState = EnemyState.IDLE;
            TransitionTo(EnemyState.IDLE);
        }
    }

    private void Chase()
    {
        float dist = Vector2.Distance(this.transform.position, player.position);

        this.transform.position = Vector2.MoveTowards(
            this.transform.position, 
            player.position, 
            ChaseSpeed * Time.deltaTime);

        //Transition to Attack
        if (dist < AttackDist)
        {
           
            TransitionTo(EnemyState.ATTACK);
            //Animation attack
        }

        //Transition to Patrol
        if(dist > PatrolDist)
        {
            
            TransitionTo(EnemyState.PATROL);
        }
    }

    private void Attack()
    {
        //Retourner a mode CHASE
        Debug.Log("Attack!");

        //Animator.Play("Attack")

        float dist = Vector2.Distance(this.transform.position, player.position);

        if (dist > AttackDist)
        {
            //currentState = EnemyState.CHASE;
            TransitionTo(EnemyState.CHASE);
        }
    }



    private void OnDrawGizmos()
    {
        //Desine le rayon de chase
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, ChaseDist);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, AttackDist);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, PatrolDist);

    }



}

public enum EnemyState
{
    IDLE,
    PATROL,
    CHASE,
    ATTACK
}
