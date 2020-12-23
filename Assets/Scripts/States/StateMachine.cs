using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine 
{
    public State currentState;

    public void ChangeState(State newState, Creature creature)
    {
        if (currentState != null)
            currentState.StateExit();

        currentState = newState;
        currentState.StateStart(creature);
    }

    public void Update()
    {
        if (currentState != null) currentState.StateUpdate();
    }
}
