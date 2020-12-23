using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{

    public CreatureSelect cSelect; 
    public Creature selected => cSelect.selectedCreature;
    private DNA _dna;


    public Text speed, size, health;

    // Update is called once per frame
    void Update()
    {

        if (selected == null) return;

        //mudar isto 
        _dna = selected.dna;

        speed.text = "Speed: " + string.Format("{0:0.000}", _dna.speed);
        size.text = "Size: " +  string.Format( "{0:0.000}" ,_dna.size);
        health.text = "Health: " + _dna.health;

    }




}
