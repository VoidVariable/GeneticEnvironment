using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    protected override string text => "Searching";

  

    public override void StateExit()
    {
    }

    public override void StateUpdate()
    {
        //Check for egde of map and turn around
        RaycastHit hit;
        if (!Physics.Raycast(current.transform.position, current.transform.TransformDirection(new Vector3(0, -0.3f, -1)), out hit, Mathf.Infinity))
        {
            current.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }


        //Random rotation
        int turn = Random.Range(0, 1000);
        if (turn < 10)
        {
            current.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }

        //Move
        current.transform.position += (current.transform.rotation * -Vector3.forward) * current.Speed * Time.deltaTime;
        
        int layerId = 0;

        //If doest need to mate or is to hungry to do so
        if (current.avail < 50 || current.Health < 50)
        {
            //Food
            layerId = 8;
        }
        else
        {
            //Creature
            layerId = 9;

        }
        int layerMask = 1 << layerId;

        Collider[] targets = Physics.OverlapSphere(current.transform.position, 10, layerMask);

        if (targets.Length > 0)
        {
            GameObject target = targets[0].gameObject;

            if (target.tag == "Food")
            {
                current.token = false;
                current.stateM.ChangeState(new FollowState(target) ,current);
            }
            else
            {
                current.stateM.ChangeState(new MateState(), current);
                //if (current.SendMatingMessage(current.target))
                //    MonoBehaviour.print("Eu n sei como isto funciona");
                //else
                //    current.testedMates.Add(current.target);
            }
        }

        
    }


}
