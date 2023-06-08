using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int remainingBallAmount;
    ObjectPool objectPool;
    public bool isFinish;


    void Start()
    {
        isFinish = false;
        objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        remainingBallAmount = objectPool.poolSize;
    }

    void Update()
    {
        if (remainingBallAmount <= 0)
        {
            isFinish = true;
        }

        if (Input.GetMouseButtonUp(0) && remainingBallAmount != 0)
        {

            remainingBallAmount--;

        }
    }
}
