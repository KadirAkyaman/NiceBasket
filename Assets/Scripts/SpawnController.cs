using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;
    [SerializeField] Transform ballStartPos;
    void Start()
    {
        //var ball = objectPool.GetPooledBall();
        //ball.transform.position = ballStartPos.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))//Mouse býrakýldýðý zaman
        {
            Invoke("GetBall", 0.5f);
        }
    }

    void GetBall()
    {
        var ball = objectPool.GetPooledBall();
        ball.transform.position = ballStartPos.position;
    }
}
