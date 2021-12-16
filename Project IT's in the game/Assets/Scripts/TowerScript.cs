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

    public float shrinkTime;
    private float shrinkage;
    private float a;
    private float d;

    //https://www.youtube.com/watch?v=gNgIpyZ43oQ
    //https://www.desmos.com/calculator/ejpbodhbos

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

        //mathy bit, copied from https://www.desmos.com/calculator/ejpbodhbos

        d = Mathf.Sqrt(Mathf.Pow(cam.transform.position.x, 2) + Mathf.Pow(cam.transform.position.y, 2));


        a = Mathf.Atan2(cam.transform.position.y, cam.transform.position.x);

        //tower base section

        shrinkage = Mathf.Clamp(shrinkTime/ ScoreManager.instance.totalTimer, 0, 1);
        
        towerBase.transform.localScale = new Vector3(ScoreManager.instance.arenaScale * shrinkage, ScoreManager.instance.arenaScale * shrinkage, 1);

        d = d * .8f;

        towerBase.transform.localPosition = Quaternion.Euler(new Vector3(0, 0, a * Mathf.Rad2Deg)) * new Vector3(d, 0, 0);

        //defining vertices
        Vector3 vertice1 = new Vector3(
    (ScoreManager.instance.arenaScale / 2) * (Mathf.Cos(a - (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d)))),
    (ScoreManager.instance.arenaScale / 2) * (Mathf.Sin(a - (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d)))),
    0);                                                      
        Vector3 vertice2 = new Vector3(                      
    (ScoreManager.instance.arenaScale / 2) * (Mathf.Cos(a + (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d)))),
    (ScoreManager.instance.arenaScale / 2) * (Mathf.Sin(a + (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d)))),
    0);
        Vector3 vertice3 = new Vector3(
    ((towerBase.transform.localScale.x / 2) * (Mathf.Cos(a - (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d))))) + towerBase.transform.localPosition.x,
    ((towerBase.transform.localScale.x / 2) * (Mathf.Sin(a - (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d))))) + towerBase.transform.localPosition.y,
    0);
        Vector3 vertice4 = new Vector3(
    ((towerBase.transform.localScale.x / 2) * (Mathf.Cos(a + (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d))))) + towerBase.transform.localPosition.x,
    ((towerBase.transform.localScale.x / 2) * (Mathf.Sin(a + (Mathf.Acos(((ScoreManager.instance.arenaScale / 2) - (towerBase.transform.localScale.x / 2)) / d))))) + towerBase.transform.localPosition.y,
    0);

        //tower section 
        vertices = new Vector3[] {
            vertice4,
            vertice3,
            vertice1,
            vertice2,
        };

        mesh.vertices = vertices;

        //mesh.RecalculateBounds();
        //mesh.RecalculateNormals();
        //mesh.RecalculateTangents();

    }
}