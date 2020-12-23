using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSelect : MonoBehaviour
{
    public Creature selectedCreature;
    
    // Update is called once per frame
    void Update()
    {
        selectedCreature = null;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                selectedCreature =  hit.collider.gameObject.transform.parent.GetComponent<Creature>();
            }
        }

    }
}
