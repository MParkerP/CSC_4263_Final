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


    //---------Player Input Definitions----------//
    //'A' =>
    //'B' =>
    //'X' => 
    //'Y' =>
    //'UP' =>
    //'DOWN' =>
    //'LEFT' =>
    //'RIGHT' =>


    void StartGame()
    {
        gameState = "playing";
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
                    if (Input.GetAxis("Jump1") > 0 || Input.GetAxis("Jump2") > 0)
                    {
                        StartGame();
                    }
                }
            }
        }

    }
}
