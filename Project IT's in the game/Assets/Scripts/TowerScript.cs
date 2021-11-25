using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public Vector3 Vertice1;
    public Vector3 Vertice2;
    public Vector3 Vertice3;
    public Vector3 Vertice4;
    private Vector3[] Vertices;

    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        mesh = GetComponent<MeshFilter>().mesh = mesh;

        mesh.MarkDynamic();

        Vector3[] vertices = new Vector3[4]
{
            Vertice1,
            Vertice2,
            Vertice3,
            Vertice4
        };

        mesh.Clear();

    }

    // Update is called once per frame
    void Update()
    {
        mesh.vertices = Vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}