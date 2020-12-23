using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{

    private int layerId;
    Action<GameObject> OnFindTarget;
    protected override string text => "Searching";

    public WanderState(int layer, Action<GameObject> onFind)
    {
        this.layerId = layer;
        OnFindTarget = onFind;
    }

    public override void StateExit()
    {
    }

    public override void StateUpdate()
    {
        //Check for egde of map and turn around
        RaycastHit hit;
        if (!Physics.Raycast(current.transform.position, current.transform.TransformDirection(new Vector3(0, -0.3f, -1)), out hit, Mathf.Infinity))
        {
            current.transform.eulerAngles = new Vector3(0, UnityEngine.Random.Random.Range(0, 360), 0);
        }


        //Random rotation
        int turn = UnityEngine.Random.Range(0, 1000);
        if (turn < 10)
        {
            current.transform.eulerAngles = new Vector3(0, UnityEngine.Random.Random.Range(0, 360), 0);
        }

        //Move
        current.transform.position += (current.transform.rotation * -Vector3.forward) * current.Speed * Time.deltaTime;
            
        int layerMask = 1 << layerId;

        Collider[] targets = Physics.OverlapSphere(current.transform.position, 10, layerMask);

        if (targets.Length > 0)
        {
            GameObject target = targets[0].gameObject;
            OnFindTarget(target);
        }

        
    }


}
