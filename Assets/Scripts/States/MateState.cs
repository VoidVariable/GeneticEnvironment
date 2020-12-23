using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateState : State
{
    StateMachine stateM;

    protected override string text => ";)";

    public override void StateExit()
    {
        throw new System.NotImplementedException();
    }

    public void StateStart()
    {
        throw new System.NotImplementedException();
    }

    public void StateUpdate(Creature c)
    {
        throw new System.NotImplementedException();
    }

    public override void StateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
