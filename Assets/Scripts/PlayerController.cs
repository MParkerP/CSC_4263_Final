using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string gameState = "starting";
    private float p1Hor;
    private float p2Hor;

    public int p1PlayerSelected = 0;
    public int p2PlayerSelected = 2;

    public GameObject LeftP1Text;
    public GameObject LeftP2Text;

    public GameObject RightP1Text;
    public GameObject RightP2Text;

    public GameObject MiddleP1Text;
    public GameObject MiddleP2Text;

    public GameObject PressStartText;


    //---------Player Input Definitions----------// 
    //'A' => joystick button 0
    //'B' => joystick button 4
    //'X' => joystick button 2
    //'Y' => joystick button 3
    //'UP' => [7th axis] up
    //'DOWN' => [7th axis] down
    //'LEFT' => [6th axis] left
    //'RIGHT' => [6th axis] right

    bool canGetInput = true;
    public float inputDelay = 0.4f;
    IEnumerator InputDelay()
    {
        canGetInput = false;
        yield return new WaitForSeconds(inputDelay);
        canGetInput = true;
    }

    public void SendButtonInput(string button, int player)
    {
        if (canGetInput)
        {
            StartCoroutine(InputDelay());
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().TakeButtonInfo(button, player);
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().IncreaseComboLength(player);
        }
    }

    void StartGame()
    {
        gameState = "playing";
        PressStartText.SetActive(false);
        GameObject.Find("HUD").GetComponent<HUDscript>().StartCountdown();
    }

    void Update()
    {

        if (gameState == "starting")
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
            }
            else
            {
                PressStartText.SetActive(false);
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
            if (Input.GetAxis("A1") > 0) { SendButtonInput("A", 1); }
            if (Input.GetAxis("B1") > 0) { SendButtonInput("B", 1); }
            if (Input.GetAxis("X1") > 0) { SendButtonInput("X", 1); }
            if (Input.GetAxis("Y1") > 0) { SendButtonInput("Y", 1); }

            if (Input.GetAxis("Horizontal1") > 0) { SendButtonInput("RIGHT", 1); }
            if (Input.GetAxis("Horizontal1") < 0) { SendButtonInput("LEFT", 1); }
            if (Input.GetAxis("Vertical1") > 0) { SendButtonInput("UP", 1); }
            if (Input.GetAxis("Vertical1") < 0) { SendButtonInput("DOWN", 1); }

            //player 2 combo inputs
            if (Input.GetAxis("A2") > 0) { SendButtonInput("A", 2); }
            if (Input.GetAxis("B2") > 0) { SendButtonInput("B", 2); }
            if (Input.GetAxis("X2") > 0) { SendButtonInput("X", 2); }
            if (Input.GetAxis("Y2") > 0) { SendButtonInput("Y", 2); }

            if (Input.GetAxis("Horizontal2") > 0) { SendButtonInput("RIGHT", 2); }
            if (Input.GetAxis("Horizontal2") < 0) { SendButtonInput("LEFT", 2); }
            if (Input.GetAxis("Vertical2") > 0) { SendButtonInput("UP", 2); }
            if (Input.GetAxis("Vertical2") < 0) { SendButtonInput("DOWN", 2); }


        }

    }
}
