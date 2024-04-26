using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int p1LivesLost = 0;
    public int p2LivesLost = 0;

    public int livesCount = 5;

    public GameObject P1InputCrossedOut;
    public GameObject P2InputCrossedOut;

    public GameObject BanditWins;
    public GameObject SheriffWins;

    public GameObject controlsImage;

    private SoundManager soundManager;
    private SoundManager soundManager2;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Sheriff").GetComponent<PlayerAnimator>();
        player2 = GameObject.Find("Bandit").GetComponent<PlayerAnimator>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();   
        soundManager2 = GameObject.Find("SoundManager2").GetComponent<SoundManager>();
    }

    IEnumerator PlayerWin(int playerWinner)
    {
        GameObject winnerBanner = null;

        if (playerWinner == 1)
        {
            winnerBanner = SheriffWins;
        }

        if (playerWinner == 2)
        {
            winnerBanner = BanditWins;
        }

        winnerBanner.SetActive(true);
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(0);
    }

    public void ResetGame(int playerWinner)
    {
        StartCoroutine(PlayerWin(playerWinner));


/*        //set gamestate to player select to avoid aditional player input
        GameObject.Find("PlayerController").GetComponent<PlayerController>().SetGameState("player select");

        //display a winner banner for resepective winner
        if (playerWinner == 1) { }
        if (playerWinner == 2) { }

        //reset display of each player's lives on screen
        foreach(var life in player1Lives)
        {
            life.SetActive(true);
        }

        foreach (var life in player2Lives)
        {
            life.SetActive(true);
        }

        //reset round count display
        roundCount = 1;
        roundCountText.text = "ROUND: " + roundCount.ToString();*/

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
        soundManager2.StopMusic();
        soundManager.PlayCountDownMusic();
        waitOnLast = Random.Range(2, 6);
        one.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(2);
        two.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(waitOnLast);
        three.GetComponent<Animator>().SetTrigger("Fade");
        GameObject.Find("ButtonManager").GetComponent<buttonManager>().makePlayerCombos();
        controlsImage.SetActive(true);
        soundManager.StopMusic();
        soundManager.PlayWhipSound();
        soundManager2.PlayGameMusic();
    }

    public void StartCountdown()
    {
        StartCoroutine(countDown());
    }
}

   