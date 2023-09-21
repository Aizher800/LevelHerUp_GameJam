using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private int originalLayer;
    private Vector3 originalPosition;
    private Transform originalParent;

    private void Start()
    {
        originalLayer = gameObject.layer;
        originalPosition = transform.position;
        originalParent = transform.parent;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        gameObject.layer = originalLayer;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("ParentObj"))
        {
            // Object with "parent" tag already in the drop position, return to original position.
            transform.position = originalPosition;
            transform.parent = originalParent;
        }
        else
        {
            // No object with "parent" tag in the drop position, allow placement.
            transform.parent = null;
        }
    }
}
