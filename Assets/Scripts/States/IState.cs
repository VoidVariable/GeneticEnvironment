using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Creature current { get; set; }
    protected abstract string text { get; }

    public virtual void StateStart(Creature creature)
    {
        current = creature;
    }

    public abstract void StateUpdate();

    public abstract void StateExit();


    public override string ToString()
    {
        return text;
    }
}
