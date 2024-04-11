using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject[] HUD_Elements;

    public void PlayGame()
    {
        startMenu.SetActive(false);
        GameObject.Find("PlayerController").GetComponent<PlayerController>().SetGameState("player select");
        foreach(GameObject element in HUD_Elements)
        {
            element.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
