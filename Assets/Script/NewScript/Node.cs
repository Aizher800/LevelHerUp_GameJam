using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    int xpos = 0;
    int ypos = 0;
    GameObject visual = null;

    bool isFilled = false;

    public void DestroyNodeCollider() 
    {
        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        isFilled = true;
    }

    public void Create(GameObject parent, int x, int y)
    {
        this.gameObject.name = "Node";
        xpos = x;
        ypos = y;
        this.gameObject.transform.parent = parent.transform;
        visual = GameObject.CreatePrimitive(PrimitiveType.Quad);
        visual.transform.parent = this.gameObject.transform;
        this.gameObject.transform.localPosition = new Vector2(xpos, ypos);
        visual.transform.localScale = new Vector2(0.9f, 0.9f);

    }

    void Start() {
        var colliderObj = this.gameObject.AddComponent<BoxCollider2D>();
        colliderObj.enabled = true;
        colliderObj.isTrigger = true;
        colliderObj.size = new Vector2(0.99f, 0.99f);
    }

    public bool IsNodeFilled() 
    {
        return isFilled;
    }

}
