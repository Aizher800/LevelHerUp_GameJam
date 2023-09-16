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

}
