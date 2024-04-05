using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    int waitOnLast;

    PlayerAnimator player1;
    PlayerAnimator player2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<PlayerAnimator>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerAnimator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            StartCoroutine(countDown());
        }

        if (Input.GetKeyDown("r"))
        {
            player1.StartPlayerShoot();
        }

        if (Input.GetKeyDown("t"))
        {
            player2.StartPlayerShoot();
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

    public void StartCountdown()
    {
        StartCoroutine(countDown());
    }
}

   