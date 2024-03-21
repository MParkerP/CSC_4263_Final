using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string gameState = "starting";
    private float p1Hor;
    private float p2Hor;

    private int p1PlayerSelected = 0;
    private int p2PlayerSelected = 0;

    void Update()
    {
        if (gameState == "starting")
        {
            p1Hor = Input.GetAxis("Horizontal1");
            p2Hor = Input.GetAxis("Horizontal2");

            //p1 horizontal input for player selection
            if (p1Hor < 0)
            {
                p1PlayerSelected = 1;
                Debug.Log(p1PlayerSelected.ToString());
            }
            else if (p1Hor > 0)
            {
                p1PlayerSelected = 2;
                Debug.Log(p1PlayerSelected.ToString());
            }


            //p2 horizontal input for player selection
            if (p2Hor < 0)
            {
                p2PlayerSelected = 1;
                Debug.Log(p2PlayerSelected.ToString());
            }
            else if(p2Hor > 0) 
            {
                p2PlayerSelected = 2;
                Debug.Log(p2PlayerSelected.ToString());
            }
        }
    }
}
