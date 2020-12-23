using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSelected : MonoBehaviour
{

    public CreatureSelect s;

    public CinemachineVirtualCamera virtCam;
  

    // Update is called once per frame
    void Update()
    {
        if (s.selectedCreature != null)
        {
            virtCam.LookAt = s.selectedCreature.gameObject.transform;
            virtCam.Follow = s.selectedCreature.gameObject.transform;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            virtCam.LookAt = null;
            virtCam.Follow = null;
        }
    }
}
