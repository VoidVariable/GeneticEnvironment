using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureBrain : StateMachine
{
    private GameObject target;
    private Collider[] targets;
    private Dictionary<string,int> priorities;
    private Dictionary<string, State> states;

    public CreatureBrain(Creature creature): base(creature: creature)
    {
        
        ChangeState(new WanderState(), null);

        priorities = new Dictionary<string, int>();
        states = new Dictionary<string, State>();

        priorities.Add("Wander", 1);
        priorities.Add("Eat", 0);
        priorities.Add("Mate", 0);

        states.Add("Wander", new WanderState());
        states.Add("Eat", new EatState());
        states.Add("Mate", new MateState());

    }


    public override void Update()
    {
        base.Update();

        foreach (string i in priorities.Keys.ToList())
        {
            priorities[i] = 0;
        }
        priorities["Wander"] = 1;

        int layerMask = 1 << 8 | 1 << 9;

        targets = Physics.OverlapSphere(dude.transform.position, 10, layerMask);

        //This needs rework
        if (targets.Length > 0)
        {
            //Handle           
            if (dude.Health < (dude.dna.health * 0.5f))
            {
                priorities["Eat"] += 3;
            } 
            
            if(dude.Avail > 50)
            {
                priorities["Mate"] += 2;
            }

        }   

        //See what state has the largest priority
        string key = priorities.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        State newState = states[key];


        if (newState.GetType() != currentState.GetType())
        {
            target = GetTarget(key);
            if (target != null)
            {
                ChangeState(newState, target);
            }
        }

    }


    private GameObject GetTarget(string key)
    {
        switch (key) 
        {
            case "Eat":
                foreach(Collider c in targets) 
                {
                    if (c.gameObject.tag == "Food")
                        return c.gameObject;
                }
                return null;
            case "Mate":
                foreach (Collider c in targets)
                {
                    if (c.gameObject.tag == "Player" && c.gameObject != dude.gameObject)
                    {
                        if (!dude.testedMates.Contains(c.GetComponent<Creature>()))
                        {
                            return c.gameObject;
                        }    
                    }
                }
                return null;
            default:
                return null;

        }
    }

    


}

