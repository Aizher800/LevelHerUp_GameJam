using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void EndGame()
    {
        Debug.Log("Yo. You clicked the quit button, dawg.");
        Application.Quit();
    }
}
