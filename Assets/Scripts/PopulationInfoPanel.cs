using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationInfoPanel : MonoBehaviour
{
    public List<GameObject> creatures = new List<GameObject>();
    public Text speedAvTxt, sizeAvTxt;

    public float updtSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("UpdateInfo");

    }

    // Update is called once per frame
    void Update()
    {
            
    }


    public IEnumerator UpdateInfo()
    { 
        speedAvTxt.text = 
            $"Av. Speed: {string.Format("{0:0.000}" , GetAverageSpeed())}";
        sizeAvTxt.text =
            $"Av. Size: {string.Format("{0:0.000}", GetAverageSize())}";
        yield return new WaitForSeconds(updtSpeed);

        StartCoroutine("UpdateInfo");
    }

    public float GetAverageSpeed()
    {
        float temp = 0;
        foreach (GameObject n in creatures)
        {
            temp += n.GetComponent<Creature>().dna.speed;
        }
        return (temp / creatures.Count);
    }

    public float GetAverageSize()
    {
        float temp = 0;
        foreach (GameObject n in creatures)
        {
            temp += n.GetComponent<Creature>().dna.size;
        }
        return (temp / creatures.Count);
    }
}
