using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);
    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector3 dragStartPos;
    private Vector3 dragSpriteStartPos;

    public List<Transform> children = new List<Transform>();
    private List<Vector2> childrenOffsets = new List<Vector2>();

    private void Start()
    {
        // Find all the offsets of each child to the parent center
        foreach (Transform child in children)
        {
            childrenOffsets.Add(child.position - transform.position);
        }
    }

    private void OnMouseDown()
    {
        isDragged = true;
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragSpriteStartPos = transform.localPosition;

        ToggleColliders(false);
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = dragSpriteStartPos + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - dragStartPos);
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;

        // Check if the callback is assigned before invoking it
        dragEndedCallback.Invoke(this);

        if (CanPlaceHere())
        {
            // do nothing
        }
        else
        {
            // Return to the original position
            transform.localPosition = dragSpriteStartPos;
        }

        ToggleColliders(true);
    }

    private bool CanPlaceHere()
    {
        foreach (Vector2 offset in childrenOffsets)
        {
            Vector2 checkPosition = new Vector2(transform.position.x + offset.x, transform.position.y + offset.y);
            RaycastHit2D hit = Physics2D.Raycast(checkPosition, -Vector2.up);

            if (hit.collider != null)
            {
                Debug.Log("hit " + hit.collider.gameObject.name);
                return false;
            }
        }
        return true;
    }

    private void ToggleColliders(bool state)
    {
        var parentCollider = transform.GetComponent<BoxCollider2D>();
        if (parentCollider != null)
        {
            parentCollider.enabled = state;
        }

        foreach (Transform child in children)
        {
            var childCollider = child.GetComponent<BoxCollider2D>();
            if (childCollider != null)
            {
                childCollider.enabled = state;
            }
        }
    }
}
