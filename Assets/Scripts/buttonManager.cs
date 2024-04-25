using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class buttonManager : MonoBehaviour
{
    public GameObject[] P1CMArray;
    public GameObject[] P2CMArray;

    public string[] P1ComboString;
    public string[] P2ComboString;

    public int P1ComboLength = 0;
    public int P2ComboLength = 0;

    private PlayerController playerController;
    private HUDscript hudScript;
    private SoundManager soundManager;

    [SerializeField] private int roundDelay = 5;



    private void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        playerController = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        hudScript = GameObject.Find("HUD").GetComponent <HUDscript>();
    }

    public void IncreaseComboLength(int player)
    {
        if (player == 1) { P1ComboLength++; }
        
        if (player == 2) { P2ComboLength++; }
    }

    public void TakeButtonInfo(string button, int player)
    {
        if (player == 1)
        {
            if (button == P1ComboString[P1ComboLength])
            {
                P1CMArray[P1ComboLength].GetComponent<Info>().ButtonClicked(true);
                P1ComboLength++;
                soundManager.PlayCorrectSound();
            }
            else
            {
                P1CMArray[P1ComboLength].GetComponent<Info>().ButtonClicked(false);
                playerController.FreezeInput(1);
                soundManager.PlayIncorrectSound();
            }
        }
        
        if (player == 2)
        {
            if (button == P2ComboString[P2ComboLength])
            {
                P2CMArray[P2ComboLength].GetComponent<Info>().ButtonClicked(true);
                P2ComboLength++;
                soundManager.PlayCorrectSound();
            }
            else
            {
                P2CMArray[P2ComboLength].GetComponent<Info>().ButtonClicked(false);
                playerController.FreezeInput(2);
                soundManager.PlayIncorrectSound();
            }
        }
    }

    public void ResetButtons(int player)
    {
        if (player == 1)
        {
            P1ComboLength = 0;
            foreach(GameObject buttonImage in P1CMArray)
            {
                buttonImage.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        
        if (player == 2)
        {
            P2ComboLength = 0;
            foreach (GameObject buttonImage in P2CMArray)
            {
                buttonImage.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }


    public string[] generateCombo(int length, GameObject[] buttonArray)
    {
        string[] combo = new string[length];
        for (int i =0; i < length; i ++)
        {
            int rand = Random.Range(0, 8);
            switch (rand)
            {
                case 0:
                    combo[i] = "A";
                    buttonArray[i].GetComponent<Info>().setButton("A");
                    break;
                case 1:
                    combo[i] = "B";
                    buttonArray[i].GetComponent<Info>().setButton("B");
                    break;
                case 2:
                    combo[i] = "X";
                    buttonArray[i].GetComponent<Info>().setButton("X");
                    break;
                case 3:
                    combo[i] = "Y";
                    buttonArray[i].GetComponent<Info>().setButton("Y");
                    break;
                case 4:
                    combo[i] = "UP";
                    buttonArray[i].GetComponent<Info>().setButton("UP");
                    break;
                case 5:
                    combo[i] = "DOWN";
                    buttonArray[i].GetComponent<Info>().setButton("DOWN");
                    break;
                case 6:
                    combo[i] = "LEFT";
                    buttonArray[i].GetComponent<Info>().setButton("LEFT");
                    break;
                case 7:
                    combo[i] = "RIGHT";
                    buttonArray[i].GetComponent<Info>().setButton("RIGHT");
                    break;
            }
        }
        return combo;
    }

    public void makePlayerCombos()
    {
        P1ComboString = generateCombo(10, P1CMArray);
        P2ComboString = generateCombo(10, P2CMArray);

}

    public void StartNewRound()
    {
        StartCoroutine(SetupNextRound());
    }

    IEnumerator SetupNextRound()
    {
        playerController.SetGameState("RoundTransition");
        hideAllButtons();
        yield return new WaitForSeconds(roundDelay);

        int p1Lives = hudScript.livesCount - hudScript.p1LivesLost;
        int p2Lives = hudScript.livesCount - hudScript.p2LivesLost;

        if (p1Lives <= 0 || p2Lives <= 0)
        {
            if (p1Lives <= 0) { hudScript.ResetGame(2); } 
            if (p2Lives <= 0) { hudScript.ResetGame(1); } 
            
        }
        else
        {
            playerController.SetGameState("playing");
            hudScript.IncreaseRound();
            hudScript.StartCountdown();
        }


    }

    public void hideAllButtons()
    {
        foreach(GameObject buttonImage in P1CMArray)
        {
            buttonImage.GetComponent<SpriteRenderer>().sprite = null;
        }
        foreach (GameObject buttonImage in P2CMArray)
        {
            buttonImage.GetComponent<SpriteRenderer>().sprite = null;
        }
    }



    // Update is called once per frame
    void Update()
    {
        //player 1 wins round
        if (P1ComboLength >= P1ComboString.Length && P1ComboString.Length > 0) 
        {
            P1ComboLength = 0;
            P2ComboLength = 0;
            StartNewRound();
            GameObject.Find("Sheriff").GetComponent<PlayerAnimator>().StartPlayerShoot();
            GameObject.Find("Bandit").GetComponent<PlayerAnimator>().StartPlayerDeath();
            hudScript.ReduceLives(2);
        }

        //player 2 wins round
        if (P2ComboLength >= P2ComboString.Length && P2ComboString.Length > 0) 
        {
            P1ComboLength = 0;
            P2ComboLength = 0;
            StartNewRound();
            GameObject.Find("Bandit").GetComponent<PlayerAnimator>().StartPlayerShoot();
            GameObject.Find("Sheriff").GetComponent<PlayerAnimator>().StartPlayerDeath();
            hudScript.ReduceLives(1);
        }
    }

}
