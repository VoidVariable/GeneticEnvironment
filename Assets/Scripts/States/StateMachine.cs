using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    public State currentState;
    protected Creature creature;

    protected StateMachine(Creature creature)
    {
        this.creature = creature;
    }

    public void ChangeState(State newState, GameObject target)
    {       
        if (currentState != null)
            currentState.StateExit();

        currentState = newState;
        currentState.StateStart(creature, target);
    }

    public virtual void Update()
    {
        if (currentState != null) currentState.StateUpdate();
    }

}
