using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{

    bool isDebugEnabled = false; 
    bool firstUpdate = true;

    List<GameObject> connectedNodes = new List<GameObject>();

    void Awake() {
        var rigidBody = this.gameObject.AddComponent<Rigidbody2D>();
        rigidBody.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Node") {
            if (!connectedNodes.Contains(collision.gameObject)) {
                connectedNodes.Add(collision.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (connectedNodes.Contains(collision.gameObject))
        {
            connectedNodes.Remove(collision.gameObject);
        }
    }

    void Update()
    {
        if (isDebugEnabled)
        {
            if (connectedNodes.Count == 0)
            {
                this.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (connectedNodes.Count == 1)
            {
                this.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                this.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    public bool IsConnected()
    {
        return connectedNodes.Count == 1;
    }

    public Vector2 GetNodeConnectedPoint()
    {
        return connectedNodes[0].transform.position;
    }

    public void DestroyNodeCollider() {
        connectedNodes[0].GetComponent<Node>().DestroyNodeCollider();
    }

}
