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
    void Start()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        remainingBall.SetActive(false);
        startMenu.SetActive(true);
        scoreMenu.SetActive(false);
        continueMenu.SetActive(false);
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
        startIcon.SetActive(false);
        startMenuAnimator.SetBool("isStart", true);
        Invoke("CloseStartMenu", 1f);
    }

    void FinishGame()
    {
        scoreContinueMenuText.text = scoreController.score.ToString();
        startMenu.SetActive(false);
        scoreMenu.SetActive(false);
        remainingBall.SetActive(false);
        continueMenu.SetActive(true);
    }
    public void ContinueGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Bir sonraki level'ý aç
    }


    void CloseStartMenu()
    {
        startMenu.SetActive(false);
        remainingBall.SetActive(true);
        scoreMenu.SetActive(true);
    }
}
