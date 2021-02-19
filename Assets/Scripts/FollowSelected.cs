using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSelected : MonoBehaviour
{
    [SerializeField]
    private CreatureSelect s;

    [SerializeField]
    private CinemachineVirtualCamera virtCam;

    private Transform target;

    private void Awake()
    {
        s.OnCreatureFollow += () =>
        {
            target = s.selectedCreature.gameObject.transform;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            virtCam.LookAt = target;
            virtCam.Follow = target;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            virtCam.LookAt = null;
            virtCam.Follow = null;
        }
    }
}
