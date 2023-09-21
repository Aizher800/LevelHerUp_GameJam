using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public int XPostion { get => xpos; }
    public int YPostion { get => ypos; }

    int xpos = 0;
    int ypos = 0;
    GameObject visual = null;

    GameObject prefab = null;

    bool isFilled = false;

    bool isDebugEnabled = false;

    public void DestroyNodeCollider() 
    {
        var boxcd = this.gameObject.GetComponent<BoxCollider2D>();
        if (boxcd != null)
        {
            boxcd.enabled = false;
            Destroy(boxcd);
        }
        isFilled = true;
        if (visual)
        {
            Destroy(visual);
        }
    }

    public void Create(GameObject parent, int x, int y)
    {
        this.gameObject.name = "Node";
        xpos = x;
        ypos = y;
        this.gameObject.transform.parent = parent.transform;
        if (isDebugEnabled)
        {
            visual = GameObject.CreatePrimitive(PrimitiveType.Quad);
            visual.transform.parent = this.gameObject.transform;
            visual.transform.localScale = new Vector2(0.9f, 0.9f);
        }
        this.gameObject.transform.localPosition = new Vector2(xpos, ypos);
        
    }
        
    void Start()
    {
        if (!isFilled)
        {
            var colliderObj = this.gameObject.AddComponent<BoxCollider2D>();
            colliderObj.enabled = true;
            colliderObj.isTrigger = true;
            colliderObj.size = new Vector2(0.99f, 0.99f);
        }
        LoadPrefab();
    }

    public void SetNodeBlocked() 
    {
        DestroyNodeCollider();
        if (prefab == null) 
        {
            LoadPrefab();
        }

        if (prefab != null)
        {
            var newPosition = this.transform.position;
            newPosition.z += 1;
            visual = Instantiate(prefab, newPosition, Quaternion.identity);
            if (visual == null) 
            {
                Debug.LogError("disabled visual failed to create");
            }
        } else {
            Debug.LogError("prefab was null when trying to disable");
        }
    }

    public bool IsNodeFilled() 
    {
        return isFilled;
    }

    void LoadPrefab() 
    {
        prefab = Resources.Load<GameObject>("Prefabs/Block");
        if (prefab == null)
        {
            Debug.LogError("Failed to load block prefab");
        }
    }

}
