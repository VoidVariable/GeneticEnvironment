using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateState : State
{
    private bool response;
    protected override string text => "Mating";
    public bool type;
    
    public override void StateStart(Creature creature, GameObject target)
    {
        base.StateStart(creature, target);

        if (!type)
        {
            response = target.GetComponent<Creature>().RespontToMatingMessage(creature);
            creature.testedMates.Add(target.GetComponent<Creature>());
        }
    }

    public override void StateExit() {    }

    public override void StateUpdate()
    {
        if (target == null || !response)
        {

            current.brain.ChangeState(new WanderState(), null);
        }
  
        if (current.transform.position != target.transform.position)
        {
            current.transform.position = Vector3.MoveTowards(current.transform.position, target.transform.position, current.Speed * Time.deltaTime);
        }

    }

    //public void SendMatingMessage()
    //{
    //    if (current.testedMates.Contains(target))
    //    {
    //        return;
    //    }
    //    if (current.dna.Stnd.CheckCompatibility(target.GetComponent<Creature>().dna, avail))
    //    {
    //        return target.GetComponent<Creature>().RespontToMatingMessage(target);
    //    }
    //    current.testedMates.Add(target);
    //    return false;

    //}

}
