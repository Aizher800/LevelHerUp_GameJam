using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Credits : MonoBehaviour
{
    public GameObject overlayCredits;
    // Start is called before the first frame update
    void Start()
    {
        overlayCredits.SetActive(false);
    }

    public void ToggleCreditsButton()
    {
        overlayCredits.SetActive(!overlayCredits.gameObject.activeSelf);
        Debug.Log("Clicked Credits button");
    }


}
