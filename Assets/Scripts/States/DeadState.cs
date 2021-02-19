using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State
{
    protected override string text => "DEAD";

    public override void StateStart(Creature creature, GameObject target)
    {
        base.StateStart(creature, target);
        creature.StartCoroutine(this.BigDead());
    }

    public override void StateExit()
    {
       
    }

    public override void StateUpdate()
    {
        throw new System.NotImplementedException();
    }


    public IEnumerator BigDead()
    {
        //needs instance var 
        yield return new WaitForSeconds(2);
        GameObject.Destroy(current.gameObject);
    }
}
