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
[CustomEditor( typeof( NodeMovementPath ) )]
public class NodeMovementPathEditor : Editor {
    #region Fields

    NodeMovementPath nmp;
    int currNode = 0;

    #endregion

    void Awake() {
        nmp = (NodeMovementPath)target;
    }

    public override void OnInspectorGUI() {
        //DrawDefaultInspector();

        Debug.Log( "CurrNode: " + currNode );

        #region fixers
        //ALTERED: You should ALWAYS have a "fixer" to reset your data back to default
        //Use these if you are getting null errors again before testing a fix for the error
        //if (currNode != 0)
        //{
        //    currNode = 0;
        //}

        //nmp.nodes.Clear();
        //nmp.nodes.TrimExcess();

        #endregion



        EditorGUILayout.Separator();
        //draw node fields
        EditorGUI.indentLevel++;

        //ALTERED: Make sure there is something in the node before trying to edit the data
        if ( nmp.nodes.Count > 0 ) {
            nmp.nodes[currNode].type = (MovementType)EditorGUILayout.EnumPopup( "Node Type: ", nmp.nodes[currNode].type );
            nmp.nodes[currNode].start = EditorGUILayout.Vector3Field( "Start Pos: ", nmp.nodes[currNode].start );
            nmp.nodes[currNode].end = EditorGUILayout.Vector3Field( "End Pos: ", nmp.nodes[currNode].end );

            if ( nmp.nodes[currNode].type == MovementType.LookAndReturn ) {
                nmp.nodes[currNode].lookPoint = EditorGUILayout.Vector3Field( "Look Point: ", nmp.nodes[currNode].lookPoint );
            }
        }
        EditorGUI.indentLevel--;

        DrawButtons();

        //refresh scene view
        SceneView.RepaintAll();
    }

    void DrawButtons() {
        //Debug.Log("drawing");

        //buttons / movement through inspector
        EditorGUILayout.BeginHorizontal();
        if ( nmp.nodes.Count > 0 ) {
            if ( currNode == 0 && nmp.nodes.Count > 1 ) //ALTERED: Changed from > 0 to > 1
            {
                //first node
                if ( GUILayout.Button( "next node" ) ) {
                    Debug.Log( "moving to next" );
                    currNode++;
                }
            } else if ( currNode == 0 && nmp.nodes.Count == 1 ) { //ALTERED: changed from count = 0 to = 1
                //first and only node
                if ( GUILayout.Button( "Add node to path" ) ) {
                    Debug.Log( "adding new node" );
                    nmp.nodes.Add( new MovementNode( Vector3.zero, Vector3.zero, MovementType.Straight ) );
                    currNode++;
                }
            }
              //ALTERED:  the check to make sure we are the last, but not the only!
              else if ( currNode == nmp.nodes.Count - 1 && currNode != 0 ) {
                //last node
                if ( GUILayout.Button( "previous node" ) ) {
                    Debug.Log( "moving to last" );
                    currNode--;
                }
                if ( GUILayout.Button( "Add node to path" ) ) {
                    Debug.Log( "adding new node" );
                    nmp.nodes.Add( new MovementNode( Vector3.zero, Vector3.zero, MovementType.Straight ) );
                    currNode++;
                }
            } else {
                //not first or last
                if ( currNode != 0 ) //ALTERED: shouldnt show previous if you are on the first node!
                {
                    if ( GUILayout.Button( "previous node" ) ) {
                        Debug.Log( "moving to last" );
                        currNode--;
                    }
                }
                if ( GUILayout.Button( "next node" ) ) {
                    Debug.Log( "moving to next" );
                    currNode++;
                }
            }
        } else {
            //no nodes yet
            if ( GUILayout.Button( "Add node to path" ) ) {
                Debug.Log( "adding new node" );
                nmp.nodes.Add( new MovementNode( Vector3.zero, Vector3.zero, MovementType.Straight ) );
            }
        }
        EditorGUILayout.EndHorizontal();
    }

}