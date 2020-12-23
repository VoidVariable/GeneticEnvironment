using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationHandler : MonoBehaviour
{
    public GameObject creaturePrefab;
    public int generationSize;

    private PopulationInfoPanel pH;


    // Start is called before the first frame update
    void Start()
    {
        pH = GetComponent<PopulationInfoPanel>();
        CreateFirstGeneration();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreateFirstGeneration()
    {
        //Iterate between a set number to instatiate the creatures
        for (int i = 0; i < generationSize; i++)
        {
            //Generates unique DNA / Vou provavelmente por isto na class DNA
            DNA dna = new DNA( Random.Range(SimVars.minSize, SimVars.maxSize) ,  
                Random.Range(SimVars.minSpeed, SimVars.maxSpeed) ,Random.Range(70,100));
            //Creates random position inside the world plane. Kinda dumb.
            Vector3 pos = new Vector3(Random.Range(-29f,29f), 1, Random.Range(-29f,29f));

            GameObject c = Instantiate(creaturePrefab, pos, Quaternion.identity);
            c.GetComponent<Creature>().dna = dna;
            pH.creatures.Add(c);

        }
    }



}
