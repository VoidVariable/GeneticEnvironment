using UnityEngine;
public static class MUtils
{

    /// <summary>
    /// Dude...It's a mapped value
    /// </summary>
    /// <param name="x">Value</param>
    /// <param name="b"></param>
    /// <param name="d"></param>
    /// <param name="a"></param>
    /// <param name="c"></param>
    /// <returns></returns>
    public static float GetMappedValue(float x, float b, float d, float a = 0, float c = 0)
    {
        return (d - c) * ((x - a) / (b - a)) + c;
    }

    public static int ApplyPolarity()
    {
        int aux = Random.Range(0,2);
        if (aux == 1)
            return 1;
        return -1;
    }

}
