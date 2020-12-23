using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainHandler : MonoBehaviour
{
    private Vector3[] VerticeList;

    public Vector3 terrainSize => new Vector3(
        Mathf.Abs(VerticeList[10].x - VerticeList[0].x) * transform.localScale.x,
        0,
        Mathf.Abs(VerticeList[110].z - VerticeList[0].z) * transform.localScale.z
        );

    // Start is called before the first frame update
    void Start()
    {
        VerticeList = gameObject.GetComponent<MeshFilter>().sharedMesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
