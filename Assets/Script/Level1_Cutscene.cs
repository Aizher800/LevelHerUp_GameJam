using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_Cutscene : MonoBehaviour
{
    public GameObject Frame_1;
    // Start is called before the first frame update
    void Start()
    {
        Frame_1.SetActive(false);
    }

    public void TriggerLvl1Cutscene()
    {
        Debug.Log("Attempting to begin cutscene 1");
        Frame_1.SetActive(true);
    }
}
