using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string gameState = "starting";
    private float p1Hor;
    private float p2Hor;

    public int p1PlayerSelected = 0;
    public int p2PlayerSelected = 0;

    public GameObject LeftP1Text;
    public GameObject LeftP2Text;

    public GameObject RightP1Text;
    public GameObject RightP2Text;

    public GameObject MiddleP1Text;
    public GameObject MiddleP2Text;

    public GameObject PressStartText;
    public GameObject SelectPlayerText;

    [SerializeField] private bool p1DpadOpen = true;
    [SerializeField] private bool p2DpadOpen = true;


    //---------Player Input Definitions----------// 
    //'A' => joystick button 0
    //'B' => joystick button 4
    //'X' => joystick button 2
    //'Y' => joystick button 3
    //'UP' => [7th axis] up
    //'DOWN' => [7th axis] down
    //'LEFT' => [6th axis] left
    //'RIGHT' => [6th axis] right


    [SerializeField] private bool P1InputEnabled = true;
    [SerializeField] private bool P2InputEnabled = true;

    [SerializeField] private int frozenInputTime = 2;

    private HUDscript hudScript;

    public void SendButtonInput(string button, int player)
    {
        if (player == 1)
        {
            if (P1InputEnabled)
            {
                GameObject.Find("ButtonManager").GetComponent<buttonManager>().TakeButtonInfo(button, player);
            }
        }
        else if (player == 2)
        {
            if (P2InputEnabled)
            {
                GameObject.Find("ButtonManager").GetComponent<buttonManager>().TakeButtonInfo(button, player);
            }
        }
    }

    public void SetGameState(string state)
    {
        gameState = state;
    }

    void StartGame()
    {
        gameState = "playing";
        PressStartText.SetActive(false);
        hudScript = GameObject.Find("HUD").GetComponent<HUDscript>();
        hudScript.StartCountdown();
    }

    public void FreezeInput(int player)
    {
        StartCoroutine(FreezeInputRoutine(player));
    }

    IEnumerator FreezeInputRoutine(int player)
    {
        if (player == 1)
        {
            P1InputEnabled = false;
            hudScript.P1InputCrossedOut.SetActive(true);
            yield return new WaitForSeconds(frozenInputTime);
            hudScript.P1InputCrossedOut.SetActive(false);
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().ResetButtons(1);
            P1InputEnabled = true;
        }
        else if (player == 2)
        {
            P2InputEnabled = false;
            hudScript.P2InputCrossedOut.SetActive(true);
            yield return new WaitForSeconds(frozenInputTime);
            hudScript.P2InputCrossedOut.SetActive(false);
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().ResetButtons(2);
            P2InputEnabled = true;
        }
    }

    private void HandleDpadInput(string button, int player)
    {
        if (player == 1)
        {
            if (p1DpadOpen)
            {
                SendButtonInput(button, player);
                p1DpadOpen = false;
            }
        }
        else if (player == 2)
        {
            if (p2DpadOpen)
            {
                SendButtonInput(button, player);
                p2DpadOpen = false;
            }
        }
    }

    void Update()
    {

        if (gameState == "player select")
        {
            p1Hor = Input.GetAxis("Horizontal1");
            p2Hor = Input.GetAxis("Horizontal2");

            //hide placeholder text for player selection
            if (p1Hor != 0) { MiddleP1Text.SetActive(false); }
            if (p2Hor != 0) { MiddleP2Text.SetActive(false); }

            //p1 horizontal input for player selection
            if (p1Hor < 0)
            {
                p1PlayerSelected = 1;
                LeftP1Text.SetActive(true);
                RightP1Text.SetActive(false);
            }
            else if (p1Hor > 0)
            {
                p1PlayerSelected = 2;
                LeftP1Text.SetActive(false);
                RightP1Text.SetActive(true);
            }


            //p2 horizontal input for player selection
            if (p2Hor < 0)
            {
                p2PlayerSelected = 1;
                LeftP2Text.SetActive(true);
                RightP2Text.SetActive(false);
            }
            else if(p2Hor > 0) 
            {
                p2PlayerSelected = 2;
                LeftP2Text.SetActive(false);
                RightP2Text.SetActive(true);
            }


            //display press start text only if players are not selecting same side
            if ((p2PlayerSelected == 1 && p1PlayerSelected == 2) || (p2PlayerSelected == 2 && p1PlayerSelected == 1))
            {
                PressStartText.SetActive(true);
                SelectPlayerText.SetActive(false);
            }
            else
            {
                PressStartText.SetActive(false);
                SelectPlayerText.SetActive(true);
            }


            //start game if start pressed while active
            {
                if (PressStartText.activeSelf == true)
                {
                    if (Input.GetAxis("A1") > 0 || Input.GetAxis("A2") > 0)
                    {
                        StartGame();
                    }
                }
            }
        }
        else if (gameState == "playing")
        {

            //player 1 combo inputs
            if (Input.GetButtonDown("A1")) { SendButtonInput("A", 1); }
            if (Input.GetButtonDown("B1")) { SendButtonInput("B", 1); }
            if (Input.GetButtonDown("X1")) { SendButtonInput("X", 1); }
            if (Input.GetButtonDown("Y1")) { SendButtonInput("Y", 1); }

            if (Input.GetAxis("Horizontal1") > 0) { HandleDpadInput("RIGHT", 1); }
            if (Input.GetAxis("Horizontal1") < 0) { HandleDpadInput("LEFT", 1); }
            if (Input.GetAxis("Vertical1") > 0) { HandleDpadInput("UP", 1); }
            if (Input.GetAxis("Vertical1") < 0) { HandleDpadInput("DOWN", 1); }

            if (Input.GetAxis("Horizontal1") == 0 && Input.GetAxis("Vertical1") == 0) { p1DpadOpen = true; }

            //player 2 combo inputs
            if (Input.GetButtonDown("A2")) { SendButtonInput("A", 2); }
            if (Input.GetButtonDown("B2")) { SendButtonInput("B", 2); }
            if (Input.GetButtonDown("X2")) { SendButtonInput("X", 2); }
            if (Input.GetButtonDown("Y2")) { SendButtonInput("Y", 2); }

            if (Input.GetAxis("Horizontal2") > 0) { HandleDpadInput("RIGHT", 2); }
            if (Input.GetAxis("Horizontal2") < 0) { HandleDpadInput("LEFT", 2); }
            if (Input.GetAxis("Vertical2") > 0) { HandleDpadInput("UP", 2); }
            if (Input.GetAxis("Vertical2") < 0) { HandleDpadInput("DOWN", 2); }

            if (Input.GetAxis("Horizontal2") == 0 && Input.GetAxis("Vertical2") == 0) { p2DpadOpen = true; }


        }

    }
}
