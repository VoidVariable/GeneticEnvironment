using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public GameObject followCamera;
    public CreatureSelect s;

    public void Awake()
    {
        s.OnCreatureFollow += () =>
        {
            followCamera.SetActive(true);
        };
    }

    // Update is called once per frame
    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Escape))
            followCamera.SetActive(false);
    }
}
