using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State
{

    GameObject target;

    protected override string text => "FOOD";

    public override void StateExit()
    {
    }

    public FollowState(GameObject target)
    {
        this.target = target;
    }

    public override void StateStart(Creature creature)
    {
        base.StateStart(creature);       
    }

    public override void StateUpdate()
    {

        if (target == null)
        {
            current.stateM.ChangeState(new WanderState(), current);
            return;
        }

        current.transform.position = 
            Vector3.MoveTowards(current.transform.position, target.transform.position, current.Size * Time.deltaTime);
        //current.transform.LookAt(current.target.transform.position);

        int layerId = 8;
        int layerMask = 1 << layerId;


        if (Physics.OverlapSphere(current.transform.position, 1 + current.transform.localScale.x, layerMask).Length > 0)
        {
            current.Health += 10;
            Object.Destroy(target);

        }
    }
}
