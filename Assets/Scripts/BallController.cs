using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float lifeTime;
    ObjectPool objectPool;


    Rigidbody ballRb;
    SwipeController swipeController;
    private void Start()
    {
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

    void SetActiveChange()
    {
        objectPool.ReturnPooledBall(gameObject);
        ballRb.isKinematic = true;
        swipeController.isThrow = false;
    }
}
