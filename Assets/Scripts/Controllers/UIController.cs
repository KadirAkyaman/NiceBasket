using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject remainingBall;
    [SerializeField] TextMeshProUGUI remainingText;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject startIcon;
    [SerializeField] Animator startMenuAnimator;
    [SerializeField] GameObject scoreMenu;

    [SerializeField] GameObject continueMenu;
    [SerializeField] TextMeshProUGUI scoreContinueMenuText;

    ObjectPool objectPool;
    GameManager gameManager;
    ScoreController scoreController;

    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource finalWhistle;
    bool finishSoundCheck;

    [SerializeField] GameObject levelMenu;
    [SerializeField] TextMeshProUGUI level;

    public bool isStart = false;
    void Start()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        level.text = "Level " + gameManager.levelCount.ToString();

        if (SceneManager.GetActiveScene().buildIndex == 0)//eðer ilk seviyeyse
        {
            levelMenu.SetActive(false);
            remainingBall.SetActive(false);
            startMenu.SetActive(true);
            scoreMenu.SetActive(false);
            continueMenu.SetActive(false);
        }
        else
        {
            continueMenu.SetActive(false);
            CloseStartMenu();
        }
    }

    void ClickSound()
    {
        clickSound.Play();
    }
    private void Update()
    {
        remainingText.text = gameManager.remainingBallAmount.ToString();

        if (gameManager.isFinish)
        {
            Invoke("FinishGame", 2.5f);
        }
    }
    public void StartGame()
    {
        isStart = true;
        levelMenu.SetActive(true);
        ClickSound();
        startIcon.SetActive(false);
        startMenuAnimator.SetBool("isStart", true);
        Invoke("CloseStartMenu", 1f);
    }

    void FinishGame()
    {
        if (!finishSoundCheck)                                      //WHISTLE
        {
            finalWhistle.Play();
            finishSoundCheck = true;
        }
        scoreContinueMenuText.text = scoreController.score.ToString();
        startMenu.SetActive(false);
        scoreMenu.SetActive(false);
        remainingBall.SetActive(false);
        continueMenu.SetActive(true);
    }
    public void ContinueGame()
    {
        ClickSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Bir sonraki level'ý aç
    }


    void CloseStartMenu()
    {
        startMenu.SetActive(false);
        remainingBall.SetActive(true);
        scoreMenu.SetActive(true);
    }
}
