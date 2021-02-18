using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Creature : MonoBehaviour
{

    public DNA dna;

    public float Speed { get; private set; }
    public float Size { get; private set; }
    public float Health { get; set; }
    public int avail = 0;


    //States
    public StateMachine brain;


    private Vector3 movementVector;


    public List<Creature> testedMates;

    WaitForSeconds justWait = new WaitForSeconds(0.3f);


    //Movement 
    public bool token;
    private Vector3 startPos;
    public string CreatureName { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        brain = new CreatureBrain(this);
        StartCoroutine("DieInside");
        avail = 0;      
        Health = dna.health;
        Speed = dna.speed;
        Size = dna.size;

        transform.localScale = new Vector3(1,1,1);
        transform.localScale *= Size;
        movementVector = new Vector3(0, 0, 0);


        //Select Name From TextFile
        using (StreamReader sr = new StreamReader("Assets/Resources/CreaturesNames.txt"))
        {
           int index = Random.Range(0, 50);

            for (int i = 1; i < index; i++)
                sr.ReadLine();
            CreatureName = sr.ReadLine();
        }
        
        ChangeColor(GetColor(Speed));
    }

    public void ChangeColor(Color selfColor)
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", selfColor);
        transform.GetChild(0).GetComponent<Renderer>().SetPropertyBlock(props);
    }

    public Color GetColor(float speed)
    {
        //0 225
        float hue = MUtils.GetMappedValue(speed, a: 3, b: 7, d: 225);
        float sat = 100;
        float bright = 73;

        return Color.HSVToRGB(hue/360f, sat / 100f, bright / 100f);
    }


    // Mating Function. Tenho de fazer um script para isto
    public void MateState(Creature target)
    {
        if (avail < 50)
            return;

        GameObject c = Instantiate(gameObject, transform.position + new Vector3(3,1,0), Quaternion.identity);
        c.GetComponent<Creature>().dna = dna.Mutate(target.dna);
        avail = 0;
        target.avail = 0;
        testedMates.Clear();
        target.testedMates.Clear();
    }

   
    public bool RespontToMatingMessage(Creature target)
    {   
        if(dna.Stnd.CheckCompatibility(target.dna, avail))
        {
            return true;
        }

        MateState m = new MateState();
        m.type = true;

        brain.ChangeState(m, target.gameObject);
        testedMates.Add(target);

        return true;

    }



    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            this.enabled = false;
            ChangeColor(Color.black);

        }
        brain.Update();
    }


    public IEnumerator DieInside()
    {
        yield return justWait;
        Health--;
        avail++;
        StartCoroutine("DieInside");
    }


}


