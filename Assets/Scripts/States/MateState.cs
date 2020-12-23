using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateState : State
{
    StateMachine stateM = new StateMachine();

    protected override string text => ";)";

    public override void StateStart(Creature creature)
    {
        base.StateStart(creature);
        stateM = new StateMachine();
        stateM.ChangeState(new WanderState(9, SendMatingMessage), creature);
    }

    public override void StateExit() {    }

    public override void StateUpdate()
    {

    }

    public void SendMatingMessage(GameObject target)
    {
        if (current.testedMates.Contains(target))
        {
            return;
        }
        if (current.dna.Stnd.CheckCompatibility(target.GetComponent<Creature>().dna, avail))
        {
            return target.GetComponent<Creature>().RespontToMatingMessage(target);
        }
        current.testedMates.Add(target);
        return false;

    }

}
