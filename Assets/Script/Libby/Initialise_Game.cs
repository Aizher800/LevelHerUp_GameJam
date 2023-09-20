using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initialise_Game : MonoBehaviour
{

    public void Initialise_Game_f()
    {
        Debug.Log("Game initialising");
        SceneManager.LoadScene("Home");
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialise_Game_f();
    }
}
