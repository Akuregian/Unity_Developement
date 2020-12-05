using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Grid))]
public class EditorScript : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        Grid grid = (Grid)target;

        if (GUILayout.Button("Generate")) {
            grid.GenerateMap();
        }

        if (grid.autoDraw) {
           grid.GenerateMap();
        }
    }
}
