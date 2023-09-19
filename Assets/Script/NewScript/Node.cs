using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    GameObject piece = null;
    int xpos = 0;
    int ypos = 0;
    GameObject visual = null;
    public void Create(GameObject parent, int x, int y)
    {
        xpos = x;
        ypos = y;
        this.gameObject.transform.parent = parent.transform;
        visual = GameObject.CreatePrimitive(PrimitiveType.Quad);
        visual.transform.parent = this.gameObject.transform;
        this.gameObject.transform.position = new Vector2(xpos, ypos);
        visual.transform.localScale = new Vector2(0.9f, 0.9f);
        var colliderObj = this.gameObject.AddComponent<BoxCollider2D>();
        colliderObj.size = new Vector2(0.99f, 0.99f); 
    }


    public bool IsOccupied()
    {
        return piece != null;
    }

    public void AddGameObject(GameObject piece)
    {

    }

}
