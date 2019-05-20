using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapper : MonoBehaviour {

    public static string currentScene = "AR";

    public void SwapResearch()
    {
        SceneManager.LoadScene("Research");
        currentScene = "Research";
    }

    public void SwapScanner()
    {
        SceneManager.LoadScene("AR");
        currentScene = "AR";
    }
}
