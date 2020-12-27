using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine 
{
    public State currentState;
    protected Creature dude;

    protected StateMachine(Creature creature)
    {
        dude = creature;
    }

    public void ChangeState(State newState, GameObject target)
    {       
        if (currentState != null)
            currentState.StateExit();

        currentState = newState;
        currentState.StateStart(dude, target);
    }

    public virtual void Update()
    {
        if (currentState != null) currentState.StateUpdate();
    }

}
