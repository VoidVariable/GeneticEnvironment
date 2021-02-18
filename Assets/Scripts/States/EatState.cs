using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatState : State
{
    protected override string text => "FOOD";

    public override void StateExit()
    {
        
    }

    public override void StateUpdate()
    {

        if (target == null)
        {
            current.brain.ChangeState(new WanderState(), null);
        }
        else
        {
            current.transform.position = Vector3.MoveTowards(current.transform.position, target.transform.position, current.Speed * Time.deltaTime);
        }

        //current.transform.LookAt(current.target.transform.position);

        int layerId = 8;
        int layerMask = 1 << layerId;


        if (Physics.OverlapSphere(current.transform.position, 1 + current.transform.localScale.x, layerMask).Length > 0)
        {
            current.Health += 50;
            Object.Destroy(target);
        }

    }

}
