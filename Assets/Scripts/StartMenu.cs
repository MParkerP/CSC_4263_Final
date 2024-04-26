using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject[] HUD_Elements;
    public SoundManager soundManager;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

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

    public void buttonHoverSound()
    {
        soundManager.PlayButtonHover();
    }

    public void buttonClickSound()
    {
        soundManager.PlayButtonClick();
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
