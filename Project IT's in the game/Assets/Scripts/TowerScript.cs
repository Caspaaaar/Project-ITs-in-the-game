using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MeshFilter))]
//[RequireComponent(typeof(MeshRenderer))]

public class TowerScript : MonoBehaviour
{
    private Mesh mesh;
    public Vector3[] vertices;
    private int[] indeces;
    private MeshFilter mf;
    public GameObject towerBase;

    public float shrinkageModifier;
    private float shrinkage;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh.name = "towerBase";

        indeces = new int[] {
            0, 1, 3,   1, 2, 3
        };

        mesh.vertices = vertices;
        mesh.triangles = indeces;
        mesh.MarkDynamic();

        mf = GetComponent<MeshFilter>();
        mf.sharedMesh = mesh;

        
    }

    // Update is called once per frame
    void Update()
    {


        //de face laat op het moment zn verkeerde kant zien waardoor hij doorzichtig is !!!


        shrinkage = (ScoreManager.instance.totalTimer * shrinkageModifier);

        //tower section
        vertices = new Vector3[] {
            RotatePointAroundPivot(new Vector3(-ScoreManager.instance.arenaScale/2,-shrinkage,0), new Vector3(0,0,0), new Vector3(0,0,0)),
            RotatePointAroundPivot(new Vector3(-ScoreManager.instance.arenaScale/2,0 , 0), new Vector3(0,0,0), new Vector3(0,0,0)),
            RotatePointAroundPivot(new Vector3(ScoreManager.instance.arenaScale/2,0 ,0), new Vector3(0,0,0), new Vector3(0,0,0)),
            RotatePointAroundPivot(new Vector3(ScoreManager.instance.arenaScale/2,-shrinkage,0), new Vector3(0,0,0), new Vector3(0,0,0))
        };

        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        //tower base section
        
        towerBase.transform.localScale = new Vector3(ScoreManager.instance.arenaScale, ScoreManager.instance.arenaScale, 1);
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
}