using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour {
    Grid grid;
    Vector3 mOffSet;
    private float mZCoord;

    void Start() {
        grid = FindObjectOfType<Grid>();
    }

    private void OnMouseDrag() {
        transform.position = MouseWorldPos() + mOffSet;
    }

    private void OnMouseDown() {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffSet = gameObject.transform.position - MouseWorldPos();
    }

    public void OnMouseUp() {
        gameObject.transform.position = grid.ClosestSnapPoint(gameObject.transform.position);
    }

    private Vector3 MouseWorldPos() {
        // This is a Pixel Coordinate (x,y) --> we need a z axis
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint); // <-- Converts Screen Point to World Point, using that Z-axis we created
    }
}
