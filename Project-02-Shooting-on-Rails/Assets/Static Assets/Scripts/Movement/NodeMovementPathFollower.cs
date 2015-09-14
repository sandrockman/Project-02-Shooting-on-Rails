using UnityEngine;
using System.Collections;

/// <summary>
/// Author: Matt Gipson
/// Contact: Deadwynn@gmail.com
/// Domain: www.livingvalkyrie.com
/// 
/// Description: NodeMovementPathFollower 
/// </summary>
public class NodeMovementPathFollower : MonoBehaviour {
    #region Fields

    public GameObject pathObject;
    NodeMovementPath path;
    public bool walkPath;
    public int nodeIndex;
    MovementNode currNode;
    bool nodeComplete;

    #endregion

    void Start() {
        path = pathObject.GetComponent<NodeMovementPath>();

        //StartCoroutine( "WalkPath" );
        //set index if valid, else make valid
        if (nodeIndex < path.nodes.Count && nodeIndex >= 0) {
            currNode = path.nodes[nodeIndex];
        } else {
            if (nodeIndex < 0) {
                nodeIndex = 0;
            } else {
                nodeIndex = path.nodes.Count - 1;
            }
        }
    }

    void Update() {
        if (walkPath) {
            currNode = path.nodes[nodeIndex];
            switch (currNode.type) {
                case MovementType.Straight:
                    Vector3 currPos = transform.position;
                    Vector3 newPos = Vector3.Lerp(currPos, currNode.end, currNode.travelTime * Time.deltaTime);
                    transform.position = newPos;

                    Vector3 distanceToEnd = transform.position - currPos;
                    print(distanceToEnd.magnitude);
                    if (distanceToEnd.magnitude < 0.01f) {
                        //test magnitude to position
                        nodeComplete = true;
                    }
                    break;
                case MovementType.Wait:
                    break;
                case MovementType.LookAndReturn:
                    break;
                case MovementType.Bezier:
                    break;
                default:
                    goto case MovementType.Straight;
            }

            if (nodeComplete) {
                if (nodeIndex < path.nodes.Count - 1) {
                    print("node up");
                    nodeIndex++;
                }
                nodeComplete = false;
            }
        }
    }

    IEnumerator WalkPath() {
        print("coroutine running");
        yield return null;
    }
}