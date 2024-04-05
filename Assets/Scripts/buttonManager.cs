using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    public GameObject[] P1CMArray;
    public GameObject[] P2CMArray;

    public string[] P1ComboString;
    public string[] P2ComboString;

    public int P1ComboLength = 0;
    public int P2ComboLength = 0;

    public void IncreaseComboLength(int player)
    {
        if (player == 1) { P1ComboLength++; }
        else if (player == 2) { P2ComboLength++; }
    }

    public void TakeButtonInfo(string button, int player)
    {
        if (player == 1)
        {
            if (button == P1ComboString[P1ComboLength])
            {
                P1CMArray[P1ComboLength].GetComponent<Info>().ButtonClicked(true);
            }
            else
            {
                P1CMArray[P1ComboLength].GetComponent<Info>().ButtonClicked(false);
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



    // Update is called once per frame
    void Update()
    {
        if (P1ComboLength >= P1ComboString.Length && P1ComboString.Length > 0) 
        {
            P1ComboLength = 0;
            GameObject.Find("HUD").GetComponent<HUDscript>().StartPlayer1Shoot(); 
        }
        if (P2ComboLength >= P2ComboString.Length && P2ComboString.Length > 0) 
        { 
            P2ComboLength = 0;
            GameObject.Find("HUD").GetComponent<HUDscript>().StartPlayer2Shoot(); 
        }
    }

}
