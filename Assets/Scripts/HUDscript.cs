using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDscript : MonoBehaviour
{
    [SerializeField] GameObject one;
    [SerializeField] GameObject two;
    [SerializeField] GameObject three;
    int waitOnLast;

    PlayerAnimator player1;
    PlayerAnimator player2;

    [SerializeField] private int roundCount = 1;
    public TextMeshProUGUI roundCountText;

    [SerializeField] private GameObject[] player1Lives;
    [SerializeField] private GameObject[] player2Lives;

    private int p1LivesLost = 0;
    private int p2LivesLost = 0;

    public GameObject P1InputCrossedOut;
    public GameObject P2InputCrossedOut;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Sheriff").GetComponent<PlayerAnimator>();
        player2 = GameObject.Find("Bandit").GetComponent<PlayerAnimator>();

    }

    public void ReduceLives(int player)
    {
        if (player == 1)
        {
            player1Lives[p1LivesLost].SetActive(false);
            p1LivesLost++;
        }

        if (player == 2)
        {
            player2Lives[p2LivesLost].SetActive(false);
            p2LivesLost++;
        }
    }

    public void IncreaseRound()
    {
        roundCount++;
        roundCountText.text = "ROUND: " + roundCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetKeyDown("l"))
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
        }*/
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

   