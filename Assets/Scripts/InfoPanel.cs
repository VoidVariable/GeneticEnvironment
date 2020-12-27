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
        speed.text = "Speed: " + string.Format("{0:0.000}", _dna.speed) + "m/s";
        size.text = "Size: " +  string.Format( "{0:0.000}" ,_dna.size) + "m";
        health.text = "Health: " + _dna.health + " / " + selected.Health;

        PrintState();
        
    }

    private void PrintState()
    {

        if(selected.Health <= -400)
        {
            state.text = "DEAD";
            return;
        }

        state.text = selected.brain.currentState.ToString();
    }

    private void SelectCreature()
    {
        selected = cSelect.selectedCreature;
    }

}
