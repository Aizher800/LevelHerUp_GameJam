using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    int xBoardDimension = 9;
    int yBoardDimension = 3;
    
    List<GameObject> nodes = null;

    public bool HasGameBeenWon { get; private set; } = false;


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
        DisableBoardNodeAt(1, 0);
        DisableBoardNodeAt(7, 1);
    }

    void Update()
    {
        HasGameBeenWonCheck();
        if (HasGameBeenWon)
        {
            SceneLoader("Home");
            // Insert load scene here
        }
    }

    void DisableBoardNodeAt(int xpos, int ypos) 
    {
        foreach (var nodeObj in nodes) 
        {
            var node = nodeObj.GetComponent<Node>();
            if (node.XPostion == xpos && node.YPostion == ypos)
            {
                Debug.Log("Node has been found disable");
                node.SetNodeBlocked();
            }
        }
    }

    void HasGameBeenWonCheck() 
    {
        if (!HasGameBeenWon)
        {
            bool isGameWon = true;
            foreach (var nodeObj in nodes)
            {
                var node = nodeObj.GetComponent<Node>();
                if (!node.IsNodeFilled())
                {
                    isGameWon = false;
                    break;
                }
            }
            HasGameBeenWon = isGameWon;
        }
    }

        public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    
    }
}
