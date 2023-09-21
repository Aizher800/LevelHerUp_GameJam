using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomList : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public int listSize;


    // Update is called once per frame
    void Start()
    {
        Random.Range(0, listSize); 

        PrintList();
        //step 1 instantiate 1st object on list
        GameObject newObject = Instantiate(gameObjects[0], new Vector3(0,0,0), Quaternion.identity);
        gameObjects.RemoveAt(0);

        //step 2 shuffle elements up
        //for (int i = 1;  i < gameObjects.Count; i++)
        //{
        //    gameObjects[i-1] = gameObjects[i];        
        //}

        ////step 3 resize list -1
        //gameObjects[listSize - 1] = null;
        PrintList(); 

    }
    void PrintList()
    {
        listSize = 2;

        for (int i = 0; i < gameObjects.Count; i++)
        {
            Debug.Log(gameObjects[i]);
        }

    }
}
