using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{
    void Start()
    {
        BuildMesh();
    }

    void BuildMesh() {

        //Generate the new mesh data
        Vector3[] vertices = new Vector3[4];
        int[] triangles = new int[6]; // starting simple, a sqaure with 2 triagles contains 6 points
        Vector3[] normals = new Vector3[4]; // Normals are the vector pointing Orthagonal to the surface. Used in Shading surfaces

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 0, -1);
        vertices[3] = new Vector3(1, 0, -1);

        triangles[0] = 0;
        triangles[1] = 3;
        triangles[2] = 2;

        triangles[3] = 0;
        triangles[4] = 1;
        triangles[5] = 3;

        normals[0] = Vector3.up;
        normals[1] = Vector3.up;
        normals[2] = Vector3.up;
        normals[3] = Vector3.up;

        // Create a new Mesh and populate with data;
        Mesh mesh = new Mesh();
        mesh.vertices = vertices; //
        mesh.triangles = triangles;
        mesh.normals = normals;



        // Assign out mesh to our filter/renderer/collider;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshRenderer meshRender = GetComponent<MeshRenderer>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();

        meshFilter.mesh = mesh;
    }
}
