using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlaySpawner : MonoBehaviour
{
    public GameObject overlayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        overlayCanvas.SetActive(false);
    }

 //   public void ToggleOverlayKey()
 //   {
 //      if (Input.GetKeyDown(KeyCode.Escape))
 //       {
 //           overlayCanvas.SetActive(!overlayCanvas.gameObject.activeSelf);
 //       }
 //
 //   }

    public void ToggleOverlayButton()
    {    
    overlayCanvas.SetActive(!overlayCanvas.gameObject.activeSelf);
    }

}
