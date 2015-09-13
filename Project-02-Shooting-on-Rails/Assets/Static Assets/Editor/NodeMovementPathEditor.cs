using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPathEditor is a custom editor
/// </summary>
[CustomEditor(typeof(NodeMovementPath))]
public class NodeMovementPathEditor : Editor {
    #region Fields
	
    #endregion

	public override void OnInspectorGUI(){
        NodeMovementPath nodeMovementPath = (NodeMovementPath)target;
        //DrawDefaultInspector();

    } 

}