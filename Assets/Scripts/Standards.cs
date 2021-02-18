using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Standards 
{ 
    private float speedWeight;
    private float sizeWeight; 

    public float SpeedWeight
    {
        private set
        {
            speedWeight = Mathf.Clamp(value, -1, 1);
        }
        get
        {
            return speedWeight;
        }
    }
    public float SizeWeight
    {
        private set
        {
            sizeWeight = Mathf.Clamp(value, -1, 1);
        }
        get
        {
            return sizeWeight;
        }
    }



    public Standards(float sizeW, float speedW) :this()
    {
        SpeedWeight = speedW;
        SizeWeight = sizeW;
    }

    public bool CheckCompatibility(DNA dna, int availPercent)
    {
        float value = 0;

        //Size Value
        float sizePercent = MUtils.GetMappedValue(dna.size,
            a: SimVars.minSize, b: SimVars.maxSize, c: -100, d: 100);
        value += sizePercent * this.SizeWeight;

        //Speed Value
        float speedPercent = MUtils.GetMappedValue(dna.speed,
            a: SimVars.minSpeed, b: SimVars.maxSpeed, c: -100, d: 100);
        value += speedPercent * this.SpeedWeight;

        Debug.Log(value);

        if (value < availPercent)
            return true;

        return false;
    }


}
