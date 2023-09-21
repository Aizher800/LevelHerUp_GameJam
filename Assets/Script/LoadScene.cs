using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject LoseScreen;

    public void LoseGame()
    {
        LoseScreen.SetActive(true);
        StartCoroutine(DelayLoseLoad());
        Debug.Log("You've pressed the restart button");
        Debug.Log("Please wait for 3 seconds");
    }

    IEnumerator DelayLoseLoad()
    {
        yield return new WaitForSeconds(1f);
        Restart();
    }
    //Loads scene from Home to MainGame
    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Yo. You've restarted the game, dawg.");
    }
}
