using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public State currentState { get; private set; }

    public void SetState(State state) 
    {
        if (currentState != null) 
        {
            currentState.OnStateExit();
        }
        
        currentState = state;
        currentState.OnStateEnter();
    }

    public void Tick() {
        if (currentState != null) 
        {
            currentState.Tick();
        }
    }
}

