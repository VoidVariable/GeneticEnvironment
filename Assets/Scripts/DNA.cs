using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA 
{

    public float size;
    public float speed;
    public float health;
    public Standards Stnd { get; private set; }

    public DNA(float size, float speed, float health)
    {
        this.size = size;
        this.speed = speed;
        this.health = health;
        InstatiateStandard();
    }


    private void InstatiateStandard()
    {
        
        float[] values  = new float[] {1 , Random.Range(0, 1f), 0};

        
        float value1 = (values[0] - values[1]) * MUtils.ApplyPolarity();

        float value2 = (values[1] - values[2]) * MUtils.ApplyPolarity();

        Stnd = new Standards(value1, value2);
    }


    public DNA Mutate(DNA partnerDNA)
    {
        DNA mutatedDNA = new DNA(
            (this.size + partnerDNA.size) / 2,
            (this.speed + partnerDNA.speed) / 2,
            (this.health + partnerDNA.health) / 2);
        return mutatedDNA;
    }

}
