using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node {
    public Vector3 worldPosition;
    public bool isWalk;
    int gridX, gridY;

    public Node(Vector3 _worldPosition, bool _isWalk, int _x, int _y) {
        worldPosition = _worldPosition;
        isWalk = _isWalk;
        gridX = _x;
        gridY = _y;
    }
}
