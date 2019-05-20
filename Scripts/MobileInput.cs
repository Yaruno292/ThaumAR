using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour {

    private SceneSwapper sceneSwap;

    private void Start()
    {
        sceneSwap = GetComponent<SceneSwapper>();
    }

    public void Vibrate()
    {
        Handheld.Vibrate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneSwapper.currentScene == "AR")
            {
                sceneSwap.SwapResearch();
            }
            else if (SceneSwapper.currentScene == "Research")
            {
                sceneSwap.SwapScanner();
            }
        }
    }
}
