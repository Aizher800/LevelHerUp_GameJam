using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    int xBoardDimension = 9;
    int yBoardDimension = 3;
    
    List<GameObject> nodes = null;
    List<GameObject> pieces = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        nodes = new List<GameObject>();
        for (int x = 0; x < xBoardDimension; ++x)
        {
            for (int y = 0; y < yBoardDimension; ++y)
            {
                var nodeobj = new GameObject();
                var node = nodeobj.AddComponent<Node>();
                node.Create(this.gameObject, x, y);
                nodes.Add(nodeobj);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
