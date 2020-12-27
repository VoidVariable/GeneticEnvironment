using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateState : State
{
    protected override string text => ";)";

    public override void StateStart(Creature creature, GameObject target)
    {
        base.StateStart(creature, target);
    }

    public override void StateExit() {    }

    public override void StateUpdate()
    {
        /*//Check for egde of map and turn around
        RaycastHit hit;
        if (!Physics.Raycast(current.transform.position, current.transform.TransformDirection(new Vector3(0, -0.3f, -1)), out hit, Mathf.Infinity))
        {
            current.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }


        //Random rotation
        int turn = UnityEngine.Random.Range(0, 1000);
        if (turn < 10)
        {
            current.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }

        //Move
        current.transform.position += (current.transform.rotation * -Vector3.forward) * current.Speed * Time.deltaTime;

        int layerMask = 1 << layerId;

        Collider[] targets = Physics.OverlapSphere(current.transform.position, 10, layerMask);

        if (targets.Length > 0)
        {
            GameObject target = targets[0].gameObject;
            current.stateM.ChangeState(new FollowState(target), current);
        }*/
    }

    public void SendMatingMessage(GameObject target)
    {/*
        if (current.testedMates.Contains(target))
        {
            return;
        }
        if (current.dna.Stnd.CheckCompatibility(target.GetComponent<Creature>().dna, avail))
        {
            return target.GetComponent<Creature>().RespontToMatingMessage(target);
        }
        current.testedMates.Add(target);
        return false;*/

    }

}
