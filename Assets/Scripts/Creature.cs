using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Creature : MonoBehaviour
{

    public DNA dna;

    public float Speed { get; private set; }
    public float Size { get; private set; }
    public float Health { get; set; }
    public int avail = 0;

  
    //States
    public StateMachine stateM;


    private Vector3 movementVector;

    public TextMeshPro t;


    public List<GameObject> testedMates;

    WaitForSeconds justWait = new WaitForSeconds(0.3f);


    //Movement 
    public bool token;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine("DieInside");
        avail = 0;

        stateM = new StateMachine();
        stateM.ChangeState(new WanderState(),this);

        Health = dna.health;
        Speed = dna.speed;
        Size = dna.size;

        transform.localScale = new Vector3(1,1,1);
        transform.localScale *= Size;
        movementVector = new Vector3(0, 0, 0);

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

    public bool SendMatingMessage(GameObject target)
    {
        if (testedMates.Contains(target))
        {
            return false;
        }
        if (dna.Stnd.CheckCompatibility(target.GetComponent<Creature>().dna, avail))
        {
            return target.GetComponent<Creature>().RespontToMatingMessage(target);          
        }
        testedMates.Add(target);
        return false;

    }

    public bool RespontToMatingMessage(GameObject target)
    {   
        if(dna.Stnd.CheckCompatibility(target.GetComponent<Creature>().dna, avail))
        {
            return true;
        }

        testedMates.Add(target);

        return false;

    }

    // Update is called once per frame
    void Update()
    {
        t.text = Health + "";

        if (Health <= 0)
        {
            this.enabled = false;
            ChangeColor(Color.black);

        }

        stateM.Update();

    }


    public IEnumerator DieInside()
    {
        yield return justWait;
        Health--;
        avail++;
        StartCoroutine("DieInside");
    }


}


