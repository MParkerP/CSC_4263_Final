using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer buttonSp;
    [SerializeField] Sprite[] SpriteArray;
    void Start()
    {
        buttonSp = GetComponent<SpriteRenderer>();
    }


    public void ClearButton()
    {
        buttonSp.color = new Color(255,255, 255);
    }

    public void ButtonClicked(bool correct)
    {
        if (correct) { buttonSp.color = new Color(0, 255, 0); } //green
        else 
        {
            buttonSp.color = new Color(255, 0, 0); //red
        }
    }

    public void setButton(string buttonString)
    {
        buttonSp.color = new Color(255,255,255);
        switch(buttonString)
        {
            case "A":
                buttonSp.sprite = SpriteArray[0];
                break;
            case "B":
                buttonSp.sprite = SpriteArray[1];
                break;
            case "X":
                buttonSp.sprite = SpriteArray[2];
                break;
            case "Y":
                buttonSp.sprite = SpriteArray[3];
                break;
            case "UP":
                buttonSp.sprite = SpriteArray[4];
                break;
            case "DOWN":
                buttonSp.sprite = SpriteArray[5];
                break;
            case "LEFT":
                buttonSp.sprite = SpriteArray[6];
                break;
            case "RIGHT":
                buttonSp.sprite = SpriteArray[7];
                break;
        }
    }
}
