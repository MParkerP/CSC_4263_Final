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
        }
    }
}
