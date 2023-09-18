using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void DoExitGame()
    {
        Debug.Log("Clicked Quit button");
        Application.Quit();
    }
}
