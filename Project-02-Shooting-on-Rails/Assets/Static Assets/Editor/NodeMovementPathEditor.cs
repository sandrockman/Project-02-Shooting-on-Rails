using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPathEditor is a custom editor
/// </summary>
[CustomEditor(typeof (NodeMovementPath))]
public class NodeMovementPathEditor : Editor {
    #region Fields

    NodeMovementPath nmp;

    #endregion

    void Awake() {
        nmp = (NodeMovementPath) target;
    }

    public override void OnInspectorGUI() {
        //DrawDefaultInspector();

        EditorGUILayout.Separator();

        for (int i = 0; i < nmp.nodes.Count; i++) {
            nmp.nodes[i].visibleInInspector = EditorGUILayout.Foldout(nmp.nodes[i].visibleInInspector, string.Format("Movement Node {0}", i + 1));
            Debug.Log(nmp.nodes[i].visibleInInspector);
            if (nmp.nodes[i].visibleInInspector) {
                EditorGUILayout.LabelField("stuff goes here");
            }
        }

        if (GUILayout.Button("Add node to path")) {
            Debug.Log("adding new node");
        }
    }

}