using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatingInfoPanel : MonoBehaviour
{
    [SerializeField]
    private CreatureSelect cSelect = default;
    private Creature selected;

    [SerializeField]
    private Text speed = default,
        size = default,
        availability = default;

    // Start is called before the first frame update
    void Start()
    {
        cSelect.OnCreatureSelect += SelectCreature;
    }

    private void Update()
    {
        if (selected == null) return;
        availability.text = "Availability: " + selected.Avail + "";
        
    }


    private void SelectCreature()
    {
        selected = cSelect.selectedCreature;

        Standards stnd = selected.dna.Stnd;

        speed.text = "Speed:" + string.Format(" {0:0.00} ", stnd.SpeedWeight) +
            $"| Size:" + string.Format(" {0:0.00} ", stnd.SizeWeight);

    }
}
