using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSpawner : MonoBehaviour
{
    public GameObject menuToggle;
    bool isToggled = false;

    void Start()
    {
        menuToggle.SetActive(isToggled);
    }

    public void ToggleMenuButton()
    {
        isToggled = !isToggled;
        menuToggle.SetActive(isToggled);
    }
}
