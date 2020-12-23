using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public GameObject followCamera;
    public CreatureSelect s;

    // Update is called once per frame
    void Update()
    {
        if (s.selectedCreature != null)
            followCamera.SetActive(true);
        if(Input.GetKeyDown(KeyCode.Escape))
            followCamera.SetActive(false);
    }
}
