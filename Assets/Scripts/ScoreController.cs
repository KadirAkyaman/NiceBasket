using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;

    [SerializeField] AudioSource basketSound;
    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
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
        }

    }


    public void ScoreUpdate()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
