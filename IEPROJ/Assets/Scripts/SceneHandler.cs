using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneHandler : MonoBehaviour
{
    public void onLoadPressed()
    {
        SceneManager.LoadScene("Load");
    }
    public void onOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void onMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onStart()
    {
        SceneManager.LoadScene("Tutorial Scene");
    }

    public void onRestart()
    {
        SceneManager.LoadScene("Game");
    }
}
