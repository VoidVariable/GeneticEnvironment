using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Creature : MonoBehaviour
{

    public DNA dna;

    public float Speed { get; private set; }
    public float Size { get; private set; }
    public float Health { get; private set; }
    int avail = 0;

    public CreatureStates _state;


    private Vector3 movementVector;

    public TextMeshPro t;


    public GameObject target;

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
        _state = CreatureStates.Wander;

        Health = dna.health;
        Speed = dna.speed;
        Size = dna.size;

        transform.localScale = new Vector3(1,1,1);
        transform.localScale *= Size;
        movementVector = new Vector3(0, 0, 0);
        target = null;

        ChangeColor(GetColor(Speed));
    }

    public void ChangeColor(Color selfColor)
    {
        MaterialPropertyBlock props = new MaterialPropertyBlock();
        props.SetColor("_Color", selfColor);
        transform.GetChild(0).GetComponent<Renderer>().SetPropertyBlock(props);
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

        switch (_state)
        {
            case CreatureStates.Wander:
                WanderState();
                break;
            case CreatureStates.Follow:
                FollowState();
                break;
            case CreatureStates.Mate:
                MateState(target.GetComponent<Creature>());
                break;
        }
    }



    public Color GetColor(float speed)
    {
        //0 225
        float hue = MUtils.GetMappedValue(speed, a: 3, b: 7, d: 225);
        float sat = 100;
        float bright = 73;

        return Color.HSVToRGB(hue/360f, sat / 100f, bright / 100f);
    }

    
    public void WanderState()
    {

        //Check for egde of map and turn around
        RaycastHit hit;
        if (!Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0, -0.3f, -1)), out hit, Mathf.Infinity))
        {
            transform.eulerAngles = new Vector3(0, Random.Range(0,360), 0);
        }


        //Random rotation
        int turn = Random.Range(0,1000);
        if(turn < 10)
        {
            transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);
        }

        //Move
        transform.position += (transform.rotation * -Vector3.forward) * Speed * Time.deltaTime;


        
        if (target == null)
        {
            int layerId = 0;

            //If doest need to mate or is to hungry to do so
            if (avail < 50 || Health < 50)
            {
                //Food
                 layerId = 8;
            }
            else
            {
                //Creature
                 layerId = 9;
               
            }
            int layerMask = 1 << layerId;
          
            Collider[] targets = Physics.OverlapSphere(transform.position, 10, layerMask); 
            
            
            if (targets.Length > 0)
            {
                target = targets[0].gameObject;

                if (target.tag == "Food")
                {
                    token = false;
                    _state = CreatureStates.Follow;
                }
                else
                {
                    if (SendMatingMessage(target))
                        _state = CreatureStates.Mate;
                    else
                        testedMates.Add(target);
                }
            }

        }

    }




    public void FollowState()
    {


        if(target == null)
        {

            _state = CreatureStates.Wander;
            return; 
        }

        if (!token)
        {
            startPos = transform.position; 
            token = true;
        }


        transform.position = Vector3.MoveTowards(startPos, target.transform.position, 0.07f);

        int layerId = 8;
        int layerMask = 1 << layerId;


        if (Physics.OverlapSphere(transform.position, 1 + transform.localScale.x, layerMask).Length > 0)
        {
            Health += 10;          
            Destroy(target);

        }
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
        target._state = CreatureStates.Wander;
        target.target = null;
        this.target = null;
        _state = CreatureStates.Wander;
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

    


    public IEnumerator DieInside()
    {
        yield return justWait;
        Health--;
        avail++;
        StartCoroutine("DieInside");
    }


}


public enum CreatureStates
{
    Wander,
    Follow,
    Mate,
    Eat
}
