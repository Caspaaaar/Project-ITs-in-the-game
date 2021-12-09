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
    public GameObject cam;

    public float shrinkageModifier;
    private float shrinkage;
    private float angle;

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


        Vector2[] uvs = new Vector2[vertices.Length];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }

        mesh.uv = uvs;
    }

    // Update is called once per frame
    void Update()
    {


        //de face laat op het moment zn verkeerde kant zien waardoor hij doorzichtig is !!!


        shrinkage = (ScoreManager.instance.totalTimer * shrinkageModifier);

        angle = (Mathf.Rad2Deg * Mathf.Atan2(cam.transform.position.y, cam.transform.position.x)) + 90;

        //tower section
        vertices = new Vector3[] {
            RotatePointAroundPivot(new Vector3(-ScoreManager.instance.arenaScale/2, -shrinkage,0), new Vector3(0,0,0), new Vector3(0,0,angle)),
            RotatePointAroundPivot(new Vector3(-ScoreManager.instance.arenaScale/2, 0, 0), new Vector3(0,0,0), new Vector3(0,0,angle)),
            RotatePointAroundPivot(new Vector3(ScoreManager.instance.arenaScale/2, 0,0), new Vector3(0,0,0), new Vector3(0,0,angle)),
            RotatePointAroundPivot(new Vector3(ScoreManager.instance.arenaScale/2, -shrinkage,0), new Vector3(0,0,0), new Vector3(0,0,angle))
        };

        mesh.vertices = vertices;

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        //tower base section
        
        towerBase.transform.localScale = new Vector3(ScoreManager.instance.arenaScale, ScoreManager.instance.arenaScale, 1);
        towerBase.transform.localPosition = RotatePointAroundPivot(new Vector3(0, -shrinkage, 0), new Vector3(0, 0, 0), new Vector3(0, 0, angle));
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
}