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

    public void setButton()
    {
        int randomNum = Random.Range(0, 8);
        switch(randomNum)
        {
            case 0:
                buttonSp.sprite = SpriteArray[0];
                break;
            case 1:
                buttonSp.sprite = SpriteArray[1];
                break;
            case 2:
                buttonSp.sprite = SpriteArray[2];
                break;
            case 3:
                buttonSp.sprite = SpriteArray[3];
                break;
            case 4:
                buttonSp.sprite = SpriteArray[4];
                break;
            case 5:
                buttonSp.sprite = SpriteArray[5];
                break;
            case 6:
                buttonSp.sprite = SpriteArray[6];
                break;
            case 7:
                buttonSp.sprite = SpriteArray[7];
                break;
        }
    }
}
