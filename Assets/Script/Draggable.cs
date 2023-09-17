using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector3 dragStartPos;
    private Vector3 dragSpriteStartPos;

    public List<Transform> children = new List<Transform>();
    public List<Vector2> childrenOffsets = new List<Vector2>();
   


    void Start()
    {
        // Find all the offsets of each child to the parent center
        foreach(Transform child in children)
        {
            childrenOffsets.Add(child.position - transform.position);
        }
    }

    private void OnMouseDown()
    {
        isDragged = true; // Starts drag
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate mouse pos to screen pos
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
        dragEndedCallback(this);

        if(CanPlaceHere())
        {
            // do nothing
        }
        else
        {
            // Return to original pos
            transform.localPosition = dragSpriteStartPos;
        }

        ToggleColliders(true);
    }

    private bool CanPlaceHere()
    {
        foreach(Vector2 offset in childrenOffsets)
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
        transform.GetComponent<BoxCollider2D>().enabled = state;
        foreach(Transform child in children)
        {
            child.GetComponent<BoxCollider2D>().enabled = state;
        }
    }
}
