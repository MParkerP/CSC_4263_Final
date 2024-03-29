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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setButton(string buttonString)
    {
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
