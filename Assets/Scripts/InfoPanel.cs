using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    [SerializeField]
    private CreatureSelect cSelect = default;
    private Creature selected;
    private DNA _dna;

    [SerializeField]
    private Text state = default, nameText = default;
    [SerializeField]
    private Text speed = default, 
        size = default,
        health= default;


    private void Awake()
    {
        cSelect.OnCreatureSelect += SelectCreature;
    }

    // Update is called once per frame
    void Update()
    {

        if (selected == null) return;
        health.text = "Health: " + _dna.health + " / " + selected.Health;
        //mudar isto 

        PrintState();
       
    }

    private void PrintState()
    {

        if(selected.Health <= 0)
        {
            state.text = "DEAD";
            return;
        }

        state.text = selected.brain.currentState.ToString();
    }

    private void SelectCreature()
    {
        selected = cSelect.selectedCreature;

        nameText.text = selected.CreatureName;

        _dna = selected.dna;
        speed.text = "Speed: " + string.Format("{0:0.000}", _dna.speed) + "m/s";
        size.text = "Size: " + string.Format("{0:0.000}", _dna.size) + "m";
       
    }

}
