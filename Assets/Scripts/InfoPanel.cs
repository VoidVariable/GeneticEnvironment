using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    public CreatureSelect cSelect;
    private Creature selected;
    private DNA _dna;



    [SerializeField]
    private Text state;
    [SerializeField]
    private Text speed, size, health;


    private void Awake()
    {
        cSelect.OnCreatureSelect += SelectCreature;
    }

    // Update is called once per frame
    void Update()
    {

        if (selected == null) return;
        

        //mudar isto 
        _dna = selected.dna;

        speed.text = "Speed: " + string.Format("{0:0.000}", _dna.speed);
        size.text = "Size: " +  string.Format( "{0:0.000}" ,_dna.size);
        health.text = "Health: " + _dna.health;

        PrintState();
        
    }

    private void PrintState()
    {
        print("asd");

        switch (selected._state)
        {
            case CreatureStates.Wander:
                state.text = "Searching...";
                break;
            case CreatureStates.Follow:
                state.text = "Food...";
                break;
            case CreatureStates.Mate:
                state.text = "Mate...";
                break;

        }
    }

    private void SelectCreature()
    {
        selected = cSelect.selectedCreature;
    }

}
