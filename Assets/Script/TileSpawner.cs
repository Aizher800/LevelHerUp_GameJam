using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public List<GameObject> Tiles = new List<GameObject>();
    private int CurrentTileIndex = 0;


    private void Start()
    {
        // some code to shuffle the list
    }

    [ContextMenu("Spawn tile")]
    void SpawnTile()
    {
        GameObject newTile = Instantiate(Tiles[CurrentTileIndex], new Vector3(0, 0, 0), Quaternion.identity);

        CurrentTileIndex++;
    }
}