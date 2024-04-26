using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private string gameState = "starting";
    private float p1Hor;
    private float p2Hor;

    public int p1PlayerSelected = 0;
    public int p2PlayerSelected = 0;

    public GameObject LeftP1Text;
    public GameObject LeftP2Text;

    public GameObject RightP1Text;
    public GameObject RightP2Text;

    public GameObject MiddleP1Text;
    public GameObject MiddleP2Text;

    public GameObject PressStartText;
    public GameObject SelectPlayerText;

    [SerializeField] private bool p1DpadOpen = true;
    [SerializeField] private bool p2DpadOpen = true;


    //---------Player Input Definitions----------// 
    //'A' => joystick button 0
    //'B' => joystick button 4
    //'X' => joystick button 2
    //'Y' => joystick button 3
    //'UP' => [7th axis] up
    //'DOWN' => [7th axis] down
    //'LEFT' => [6th axis] left
    //'RIGHT' => [6th axis] right


    [SerializeField] private bool P1InputEnabled = true;
    [SerializeField] private bool P2InputEnabled = true;

    [SerializeField] private int frozenInputTime = 2;

    private HUDscript hudScript;

    private PlayerInput playerInput;

    private SoundManager soundManager;

    public GameObject pauseMenu;

    public bool gamePaused = false;

    private void Awake()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += PlayerInput_onActionTriggered;
    }

    private void Start()
    {
        soundManager.PlayMenuMusic();
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        soundManager.PlayPause();
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void PlayerInput_onActionTriggered(InputAction.CallbackContext context)
    {
        //only do actions when button is pressed (rather than on being held or released)
        if (context.started && !gamePaused)
        {

            //allow either play to pause game
            if (gameState != "starting") 
            {
                if (context.action == playerInput.actions.FindAction("Start1")) { PauseGame(); }
                if (context.action == playerInput.actions.FindAction("Start2")) { PauseGame(); }
                    if (context.action == playerInput.actions.FindAction("Start3")) { PauseGame(); }
            }

            //handle inputs during player selection
            if (gameState == "player select")
            {
                //allow usb controller to select player
                if (context.action == playerInput.actions.FindAction("LEFT1"))
                {
                    p1PlayerSelected = 1;
                    LeftP1Text.SetActive(true);
                    RightP1Text.SetActive(false);
                    MiddleP1Text.SetActive(false);
                    soundManager.PlayButtonHover();
                }

                if (context.action == playerInput.actions.FindAction("RIGHT1"))
                {
                    p1PlayerSelected = 2;
                    LeftP1Text.SetActive(false);
                    RightP1Text.SetActive(true);
                    MiddleP1Text.SetActive(false);
                    soundManager.PlayButtonHover();
                }

                //allow ps controller to select player
                if (context.action == playerInput.actions.FindAction("LEFT2"))
                {
                    p2PlayerSelected = 1;
                    LeftP2Text.SetActive(true);
                    RightP2Text.SetActive(false);
                    MiddleP2Text.SetActive(false);
                    soundManager.PlayButtonHover();
                }

                if (context.action == playerInput.actions.FindAction("RIGHT2"))
                {
                    p2PlayerSelected = 2;
                    LeftP2Text.SetActive(false);
                    RightP2Text.SetActive(true);
                    MiddleP2Text.SetActive(false);
                    soundManager.PlayButtonHover();
                }

                //start game if start pressed while active
                
                if (PressStartText.activeSelf == true)
                {
                    if (context.action == playerInput.actions.FindAction("A1") || context.action == playerInput.actions.FindAction("A2"))
                    {
                     StartGame();

                    }
                   
                }
                
            }
            //handle inputs after player selection
            else if (gameState == "playing")
            {
                //player 1 combo inputs
                if (context.action == playerInput.actions.FindAction("A1")) { SendButtonInput("A", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("B1")) { SendButtonInput("B", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("X1")) { SendButtonInput("X", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("Y1")) { SendButtonInput("Y", p1PlayerSelected); }

                if (context.action == playerInput.actions.FindAction("UP1")) { SendButtonInput("UP", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("DOWN1")) { SendButtonInput("DOWN", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("LEFT1")) { SendButtonInput("LEFT", p1PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("RIGHT1")) { SendButtonInput("RIGHT", p1PlayerSelected); }

                //player 2 combo inputs
                if (context.action == playerInput.actions.FindAction("A2")) { SendButtonInput("A", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("B2")) { SendButtonInput("B", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("X2")) { SendButtonInput("X", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("Y2")) { SendButtonInput("Y", p2PlayerSelected); }

                if (context.action == playerInput.actions.FindAction("UP2")) { SendButtonInput("UP", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("DOWN2")) { SendButtonInput("DOWN", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("LEFT2")) { SendButtonInput("LEFT", p2PlayerSelected); }
                if (context.action == playerInput.actions.FindAction("RIGHT2")) { SendButtonInput("RIGHT", p2PlayerSelected); }
            }
        }
    }

    public void SendButtonInput(string button, int player)
    {
        Debug.Log("sending " + button + " to player " + player.ToString());
        if (player == 1)
        {
            if (P1InputEnabled)
            {
                GameObject.Find("ButtonManager").GetComponent<buttonManager>().TakeButtonInfo(button, 1);
            }
        }
        
        if (player == 2)
        {
            if (P2InputEnabled)
            {
                GameObject.Find("ButtonManager").GetComponent<buttonManager>().TakeButtonInfo(button, 2);
            }
        }
    }

    public void SetGameState(string state)
    {
        gameState = state;
    }

    void StartGame()
    {
        gameState = "playing";
        PressStartText.SetActive(false);
        hudScript = GameObject.Find("HUD").GetComponent<HUDscript>();
        hudScript.StartCountdown();
        soundManager.StopMusic();
        soundManager.PlayCountDownMusic();
    }

    public void FreezeInput(int player)
    {
        StartCoroutine(FreezeInputRoutine(player));
    }

    IEnumerator FreezeInputRoutine(int player)
    {
        if (player == 1)
        {
            P1InputEnabled = false;
            hudScript.P1InputCrossedOut.SetActive(true);
            yield return new WaitForSeconds(frozenInputTime);
            hudScript.P1InputCrossedOut.SetActive(false);
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().ResetButtons(1);
            P1InputEnabled = true;
        }
        
        if (player == 2)
        {
            P2InputEnabled = false;
            hudScript.P2InputCrossedOut.SetActive(true);
            yield return new WaitForSeconds(frozenInputTime);
            hudScript.P2InputCrossedOut.SetActive(false);
            GameObject.Find("ButtonManager").GetComponent<buttonManager>().ResetButtons(2);
            P2InputEnabled = true;
        }
    }

    private void HandleDpadInput(string button, int player)
    {
        if (player == 1)
        {
            if (p1DpadOpen)
            {
                SendButtonInput(button, player);
                p1DpadOpen = false;
            }
        }
        
        if (player == 2)
        {
            if (p2DpadOpen)
            {
                SendButtonInput(button, player);
                p2DpadOpen = false;
            }
        }
    }

    void Update()
    {

        if (gameState == "player select")
        {
            //display press start text only if players are not selecting same side
            if ((p2PlayerSelected == 1 && p1PlayerSelected == 2) || (p2PlayerSelected == 2 && p1PlayerSelected == 1))
            {
                PressStartText.SetActive(true);
                SelectPlayerText.SetActive(false);
            }
            else
            {
                PressStartText.SetActive(false);
                SelectPlayerText.SetActive(true);
            }
        }





    }
}
