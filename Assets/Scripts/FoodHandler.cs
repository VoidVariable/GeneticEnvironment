using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    public GameObject food;
    public int maxFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int foodNumb = GameObject.FindGameObjectsWithTag("Food").Length;
        if(foodNumb < maxFood)
        {
            Vector3 pos = new Vector3(Random.Range(-29f, 29f), 1, Random.Range(-29f, 29f));

            Instantiate(food, pos, Quaternion.identity);
        }
    }
}
