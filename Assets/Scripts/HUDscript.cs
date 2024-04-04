using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    int waitOnLast;

    PlayerAnimator animator1;
    PlayerAnimator animator2;

    // Start is called before the first frame update
    void Start()
    {
        animator1 = GameObject.Find("Player1").GetComponent<PlayerAnimator>();
        animator2 = GameObject.Find("Player2").GetComponent<PlayerAnimator>();

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
            StartCoroutine(player1Shoot());
        }

        if (Input.GetKeyDown("t"))
        {
            StartCoroutine(player2Shoot());
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

    IEnumerator player1Shoot()
    {
        animator1.Shoot();
        yield return new WaitForSeconds(2);
        animator1.Idle();
    }

    IEnumerator player2Shoot()
    {
        animator2.Shoot();
        yield return new WaitForSeconds(2);
        animator2.Idle();
    }
}
