using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager : MonoBehaviour
{
    public GameObject[] P1CMArray;
    public GameObject[] P2CMArray;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown("l"))
        {
            for(int i = 0;i<50;i++)
            {
                P1CMArray[i].GetComponent<Info>().setButton();
            }
        }
    }

    class CMButton
    {
        private Sprite image;
        private string button;
        private Vector2 location;
        public void CMButtonConstructor(Sprite image,string button,Vector2 location)
        {
            this.image = image;
            this.button  = button;
            this.location = location;
        }


    }
}
