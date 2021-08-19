using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void onNewGame(Text text)
    {
        if (!panel.activeSelf)
        {
            text.text = "Start a new game?";
            panel.SetActive(true);
        }
        // checks if the yes button for starting a new game is enabled
        if (!panel.gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            panel.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            panel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void onQuitClicked(Text text)
    {
        if (!panel.activeSelf)
        {
            // disables the yes button for starting a new game
            panel.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            text.text = "Are you sure you want to Quit?";
            panel.SetActive(true);
            // enables the yes button for quitting
            panel.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void onButtonClosed()
    {
        panel.SetActive(false);
        if(Time.timeScale <= 0)
        {
            Time.timeScale = 1f;
        }
    }

    public void loadButton(Text text)
    {
        text.text = "Do you want to overwrite this data?";
        panel.SetActive(true);
    }

    public void deleteLoad(Text text)
    {
        text.text = "Are you sure you want to delete this data?";
        panel.SetActive(true);
    }
}
