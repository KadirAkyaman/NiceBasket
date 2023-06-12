using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;

    [SerializeField] AudioSource basketSound;

    ApplauseController applauseController;
    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();

        applauseController = GameObject.Find("Applause").GetComponent<ApplauseController>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (!other.gameObject.GetComponentInChildren<BallController>().isBasket)//eðer o topla daha önceden basket atýlmamýþsa
            {
                other.gameObject.GetComponentInChildren<BallController>().isBasket = true;
                ScoreUpdate();
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponentInChildren<BallController>().isBasket)//eðer o topla daha önceden basket atýlmamýþsa
        {
            basketSound.Play();
            applauseController.ApplausePlay();
        }

    }


    public void ScoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
