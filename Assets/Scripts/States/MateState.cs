using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateState : State
{
    private bool response;
    protected override string text => "Mating";
    public bool type;

    private Creature partner;

    public override void StateStart(Creature creature, GameObject target)
    {
        base.StateStart(creature, target);

        if (!type)
        {
            partner = target.GetComponent<Creature>();
            response = partner.RespontToMatingMessage(creature);
            creature.testedMates.Add(target.GetComponent<Creature>());
        }

        if (target == null || !response)
        {
            current.brain.ChangeState(new WanderState(), null);
        }

        current.StartCoroutine(this.SpawnAKid());
    }

    public override void StateExit() {    }

    public override void StateUpdate()
    { 
        if (current.transform.position != target.transform.position)
        {
            current.transform.position = 
                Vector3.MoveTowards(current.transform.position, target.transform.position, current.Speed * Time.deltaTime);
        }
    }

    public IEnumerator SpawnAKid()
    {
        yield return new WaitForSeconds(1);
        Creature kid =
            GameObject.Instantiate(current,current.transform.position, Quaternion.identity);
        kid.dna = current.dna.Mutate(partner.dna);
        partner.Avail = 0;
        current.Avail = 0;
        kid.Avail = 0;
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
