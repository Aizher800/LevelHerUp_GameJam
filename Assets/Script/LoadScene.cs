using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //Loads scene from Home to MainGame
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Yo. You've restarted the game, dawg.");
    }

    public void EndGame()
    {
        Debug.Log("Yo. You clicked the quit button, dawg.");
        Application.Quit();
    }
}
