using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPathEditor is a custom editor for NodeMovementPath
/// </summary>
[CustomEditor(typeof (NodeMovementPath))]
public class NodeMovementPathEditor : Editor {
    #region Fields

    NodeMovementPath nmp;
    int currNode = 0;

    #endregion

    void Awake() {
        nmp = (NodeMovementPath) target;
    }

    public override void OnInspectorGUI() {
        //DrawDefaultInspector();

        EditorGUILayout.Separator();
        //draw node fields
        EditorGUI.indentLevel++;
        nmp.nodes[currNode].type = (MovementType) EditorGUILayout.EnumPopup("Node Type: ", nmp.nodes[currNode].type);
        nmp.nodes[currNode].start = EditorGUILayout.Vector3Field("Start Pos: ", nmp.nodes[currNode].start);
        nmp.nodes[currNode].end = EditorGUILayout.Vector3Field("End Pos: ", nmp.nodes[currNode].end);

        if (nmp.nodes[currNode].type == MovementType.LookAndReturn) {
            nmp.nodes[currNode].lookPoint = EditorGUILayout.Vector3Field("Look Point: ", nmp.nodes[currNode].lookPoint);
        }
        EditorGUI.indentLevel--;

        DrawButtons();

        //refresh scene view
        SceneView.RepaintAll();
    }

    void DrawButtons() {
        Debug.Log("drawing");

        //buttons / movement through inspector
        EditorGUILayout.BeginHorizontal();
        if (nmp.nodes.Count > 0) {
            if (currNode == 0 && nmp.nodes.Count > 0) {
                //first node
                if (GUILayout.Button("next node")) {
                    Debug.Log("moving to next");
                    currNode++;
                }
            } else if (currNode == 0 && nmp.nodes.Count == 0) {
                //first and only node
                if (GUILayout.Button("Add node to path")) {
                    Debug.Log("adding new node");
                    nmp.nodes.Add(new MovementNode(Vector3.zero, Vector3.zero, MovementType.Straight));
                    currNode++;
                }
            } else if (currNode == nmp.nodes.Count - 1) {
                //last node
                if (GUILayout.Button("previous node")) {
                    Debug.Log("moving to last");
                    currNode--;
                }
                if (GUILayout.Button("Add node to path")) {
                    Debug.Log("adding new node");
                    nmp.nodes.Add(new MovementNode(Vector3.zero, Vector3.zero, MovementType.Straight));
                    currNode++;
                }
            } else {
                //not first or last
                if (GUILayout.Button("previous node")) {
                    Debug.Log("moving to last");
                    currNode--;
                }
                if (GUILayout.Button("next node")) {
                    Debug.Log("moving to next");
                    currNode++;
                }
            }
        } else {
            //no nodes yet
            if (GUILayout.Button("Add node to path")) {
                Debug.Log("adding new node");
                nmp.nodes.Add(new MovementNode(Vector3.zero, Vector3.zero, MovementType.Straight));
            }
        }
        EditorGUILayout.EndHorizontal();
    }

}