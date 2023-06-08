using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float lifeTime;
    ObjectPool objectPool;

    public bool isBasket;


    Rigidbody ballRb;
    SwipeController swipeController;

    [SerializeField] AudioSource touchGround;
    private void Start()
    {
        isBasket = false;
        swipeController = GetComponent<SwipeController>();
        ballRb = GetComponent<Rigidbody>();

        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();

    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Invoke("SetActiveChange", lifeTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        touchGround.Play();
        //}
    }
    void SetActiveChange()
    {
        objectPool.ReturnPooledBall(gameObject);
        ballRb.isKinematic = true;
        swipeController.isThrow = false;
    }
}
