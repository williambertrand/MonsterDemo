using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    public State CurrentState { get; private set; }

    public void Initialize(State startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    /*
     *  On chaning state - we call exit on the current state and enter on the newly entered state
     */
    public void ChangeState(State newState)
    {
        CurrentState.Exit();

        CurrentState = newState;
        newState.Enter();
    }

}
