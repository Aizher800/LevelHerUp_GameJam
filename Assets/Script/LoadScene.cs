using System.Collections;
using System.Collections.Generic;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject LoseScreen;

    public void LoseGame()
    {
        LoseScreen.SetActive(true);
        StartCoroutine(DelayLoseLoad());
        Debug.Log("Clicked Restart button, lost game");
        Debug.Log("Please for 3 seconds until level restarts");
    }

    IEnumerator DelayLoseLoad()
    {
        yield return new WaitForSeconds(3f);
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

    public void EndGame()
    {
        Debug.Log("Clicked Quit button");
        Application.Quit();
    }
}
