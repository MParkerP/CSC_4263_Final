using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    int waitOnLast;
    // Start is called before the first frame update
    void Start()
    {
  
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            StartCoroutine(countDown());
        }
    }

    IEnumerator countDown()
    {
        waitOnLast = Random.Range(2, 6);
        one.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(2);
        two.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(waitOnLast);
        three.GetComponent<Animator>().SetTrigger("Fade");
        GameObject.Find("ButtonManager").GetComponent<buttonManager>().makePlayerCombos();
    }
}
