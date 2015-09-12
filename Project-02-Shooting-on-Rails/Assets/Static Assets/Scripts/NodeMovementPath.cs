using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPath 
/// </summary>
public class NodeMovementPath : MonoBehaviour {
    #region Fields
    
    public MovementNode[] nodes;

    #endregion

    void Start() {
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i] = new MovementNode(Vector3.zero, Vector3.one, MovementType.Straight);
        }
    }

    void Update() {}

    void OnDrawGizmos() {
        for (int i = 0; i < nodes.Length; i++) {
            Gizmos.DrawWireSphere(nodes[i].start, .5f);
        }
    }

}

[System.Serializable]
public struct MovementNode {
    //public Vector3 position;
    public Vector3 start, end;
    public Vector3 bezierControl;
    public Vector3[] lookChain;
    public MovementType type;

    public MovementNode(Vector3 startPosition, Vector3 endPosition, MovementType type) {
        start = startPosition;
        end = endPosition;
        this.type = type;
        lookChain = new Vector3[0];
        bezierControl = Vector3.zero;
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