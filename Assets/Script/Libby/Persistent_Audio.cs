using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistent_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        // MEANS AUDIO DOESN'T STOP UPON NEW SCENE OPENING/LEVEL RESTARTING
        // - FROM LIBBY
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
