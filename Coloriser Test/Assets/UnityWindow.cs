using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class UnityWindow : EditorWindow
{
    Color color;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<UnityWindow>("Colorizer");
    }

    void OnGUI()
    {
        GUILayout.Label("Color the selected object", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if (GUILayout.Button("COLORIZE!"))
        {
            Colorize();
        }
    }

    void Colorize()
    {
        GameObject selectedObject = Selection.activeGameObject;

        if (selectedObject != null)
        {
            Renderer renderer = selectedObject.GetComponent<Renderer>();

            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
            else
            {
                Debug.LogWarning("Selected object does not have a Renderer component.");
            }
        }
        else
        {
            Debug.LogWarning("No object selected.");
        }
    }
}
