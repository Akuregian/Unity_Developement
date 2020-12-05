using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Vector3 test;

    public Vector2 mapSize;
    public LayerMask obstacle;

    public RaycastHit hit;

    Node startNodePos;
    Node endNodePos;

    public Transform startNode;
    public Transform endNode;

    public bool autoDraw;
    Vector3 BottomLeftOfWorld;

    [HideInInspector]
    public bool Grabbed;

    Node[,] grid;
    int gridSizeX, gridSizeY;

    [Range(0, 1)]
    public float nodeDiameter;


    void Start() {
        Grabbed = false;
        GenerateMap();
        startNodePos = NodeFromWorldPoint(new Vector3(-9.5f, 0, -9.5f));
        endNodePos = NodeFromWorldPoint(new Vector3(9.5f, 0, 9.5f));

        startNode = Instantiate(startNode, new Vector3(startNodePos.worldPosition.x, 0, startNodePos.worldPosition.z), Quaternion.identity);
        endNode = Instantiate(endNode, new Vector3(endNodePos.worldPosition.x, 0, endNodePos.worldPosition.z), Quaternion.identity);
    }


    public Vector3 ClosestSnapPoint(Vector3 pos) {
        Node tmpNode = NodeFromWorldPoint(pos);
        return tmpNode.worldPosition;
    }

    public void GenerateMap() {
        gridSizeX = Mathf.RoundToInt(mapSize.x);
        gridSizeY = Mathf.RoundToInt(mapSize.y);

        grid = new Node[gridSizeX, gridSizeY];

        string holderName = "Generated Map";
        if (transform.Find(holderName)) {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform mapHolder = new GameObject(holderName).transform;
        mapHolder.parent = transform;

        BottomLeftOfWorld = transform.position - Vector3.right * mapSize.x / 2 + -Vector3.forward * mapSize.y / 2;

        for (int x = 0; x < gridSizeX; x++) {
            for (int y = 0; y < gridSizeY; y++) {
                Vector3 worldPosition = BottomLeftOfWorld + Vector3.right * (x * nodeDiameter + 0.5f) + Vector3.forward * (y * nodeDiameter + 0.5f) ;
                bool walkable = !(Physics.CheckSphere(worldPosition, 0.5f, obstacle));
                grid[x, y] = new Node(worldPosition, walkable, x, y);
            }
        }
    }
    public Node NodeFromWorldPoint(Vector3 worldPosition) {
        float percentX = (worldPosition.x + mapSize.x / 2) / mapSize.x;
        float percentY = (worldPosition.z + mapSize.y / 2) / mapSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
    }


    void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, new Vector3(mapSize.x, 1, mapSize.y));

        if (grid != null) {
            foreach (Node n in grid) {
                Gizmos.color = (n.isWalk) ? Color.white : Color.red;
                Gizmos.DrawCube(n.worldPosition, Vector3.one * (nodeDiameter - .1f));
            }
        }
    }
}
