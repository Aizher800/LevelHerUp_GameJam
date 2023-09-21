using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    Rigidbody2D objRigidbody;
    private Vector3 dragStartPos;
    private Vector3 dragSpriteStartPos;

    [SerializeField]
    private bool isDragged = false;
    private bool isLocked = false;

    void Start() 
    {
        objRigidbody = this.gameObject.AddComponent<Rigidbody2D>();
        objRigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    private void OnMouseDown()
    {
        if (isLocked)
        {
            return;
        }
        Debug.Log("Mouse Down");
        isDragged = true;
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragSpriteStartPos = this.transform.localPosition;

        MovePiece(-1);
    }


    void FixedUpdate() {
        if (isDragged && !isLocked)
        {
            var pos = dragSpriteStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragStartPos);
            objRigidbody.MovePosition(pos);
        }
    }

    private void OnMouseUp()
    {
        if (isLocked) {
            return;
        }
        isDragged = false;
        MovePiece(1);
        Debug.Log("Mouse Up");

        if (AreAllSegmentsConnected())
        {
            Segment[] childSegments = gameObject.GetComponentsInChildren<Segment>();
            foreach (var child in childSegments) {
                if (child.name == "Center") {
                    Debug.Log("Child found");
                    this.transform.position = child.GetNodeConnectedPoint();
                    isLocked = true;
                }
                child.DestroyNodeCollider();
            }
            MovePiece(1);
        }
        else
        {
            // Return to the original position
            this.transform.localPosition = dragSpriteStartPos;
        }
    }

    bool AreAllSegmentsConnected() 
    {
        Segment[] childSegments = gameObject.GetComponentsInChildren<Segment>();
        foreach (var child in childSegments)
        {
            var childSegment = child.GetComponent<Segment>();
            if (childSegment != null)
            {
                if (!childSegment.IsConnected())
                {
                    Debug.Log("Child segment was not connected");
                    return false;
                }
            }
        }
        return true;
    }

    void MovePiece(int z)
    {
        var newPosition = this.transform.position;
        newPosition.z += z;
        this.transform.position = newPosition;
    }

}
