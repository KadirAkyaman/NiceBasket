using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float lifeTime;

    public bool isBasket;


    Rigidbody ballRb;
    SwipeController swipeController;

    [SerializeField] AudioSource touchGround;
    [SerializeField] AudioSource touchCourt;
    [SerializeField] AudioSource touchHole;
    bool touchHolePlaying;
    private void Start()
    {
        isBasket = false;
        swipeController = GetComponent<SwipeController>();
        ballRb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround.Play();
        }
        if (collision.gameObject.CompareTag("Court"))
        {
            touchCourt.Play();
        }
        if (collision.gameObject.CompareTag("Hole"))
        {
            if (!touchHolePlaying)
            {
                touchHole.Play();
                touchHolePlaying = true;
                Invoke("TouchHoleSoundController", 0.5f);
            }
        }
    }

    void TouchHoleSoundController()//Bir obje belirli süre aralýðýnda sadece 1 kere ses yapabilsin
    {
        touchHolePlaying = false;
    }

}
