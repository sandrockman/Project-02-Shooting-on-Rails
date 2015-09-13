using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPath 
/// </summary>
public class NodeMovementPath : MonoBehaviour {
    #region Fields

    public List<MovementNode> nodes;

    #endregion

    void Start() {}

    void Update() {}

    void OnDrawGizmos() {
        //draw node spheres
        for (int i = 0; i < nodes.Count; i++) {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(nodes[i].start, .5f);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(nodes[i].end, .5f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(nodes[i].bezierControl, .5f);
        }

        //draw lines
        //broken
        for (int i = 0; i < nodes.Count; i++) {
            switch (nodes[i].type) {
                case MovementType.Straight:
                    Gizmos.color = Color.blue;
                    Gizmos.DrawRay(nodes[i].start, nodes[i].end);
                    break;
            }

        }

        SceneView.RepaintAll();
    }

}

[System.Serializable]
public class MovementNode {
    //public Vector3 position;
    public Vector3 start, end;
    public Vector3 bezierControl;
    public Vector3 lookPoint;
    public MovementType type;

    [Tooltip("the time to travel to the end or to wait if wait type node")]
    public float travelTime;

    public MovementNode(Vector3 startPosition, Vector3 endPosition, MovementType type = MovementType.Straight) {
        start = startPosition;
        end = endPosition;
        this.type = type;
        lookPoint = Vector3.zero;
        bezierControl = Vector3.zero;
        travelTime = 0;
    }
}

public enum MovementType {
    Straight,
    Bezier,
    LookAndReturn,
    LookChain,
    Wait

}

#region Outline

/*
    Node[] for nodes
    enum for node type


*/

#endregion