using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSelect : MonoBehaviour
{
    public Creature selectedCreature;

    public event Action OnCreatureSelect;

    // Update is called once per frame
    void Update()
    {
        selectedCreature = null;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            int layerId = 9;
            int layerMask = 1 << layerId;

            if (Physics.Raycast(ray, out hit, 200.0f, layerMask))
            {
                selectedCreature =  hit.collider.gameObject.GetComponent<Creature>();
                OnCreatureSelect?.Invoke();
            }
        }

    }
}
