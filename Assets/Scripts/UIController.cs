using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject score;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject startIcon;
    [SerializeField] Animator startMenuAnimator;
    void Start()
    {
        score.SetActive(false);
        startMenu.SetActive(true);
    }

    public void StartGame()
    {
        startIcon.SetActive(false);
        startMenuAnimator.SetBool("isStart", true);
        Invoke("CloseStartMenu", 1f);
    }

    void CloseStartMenu()
    {
        startMenu.SetActive(false);
        score.SetActive(true);
    }
}
