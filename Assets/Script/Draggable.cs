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
   


    void Start()
    {

    }

    private void OnMouseDown()
    {
        isDragged = true; // Starts drag
        dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //translate mouse pos to screen pos
        dragSpriteStartPos = transform.localPosition;
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
        //if object dragged onto object
        //delete this object

    }
}
