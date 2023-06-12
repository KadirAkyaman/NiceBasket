using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int remainingBallAmount;
    ObjectPool objectPool;
    public bool isFinish;

    public int levelCount;

    UIController uIController;

    bool started = false;
    void Start()
    {
        uIController = GameObject.Find("Canvas").GetComponent<UIController>();
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

        if (uIController.isStart)
        {
            Invoke(nameof(Started), 0.5f);
        }

        if (levelCount == 1 && started)
        {
            if (Input.GetMouseButtonUp(0) && remainingBallAmount != 0)
            {
                remainingBallAmount--;
            }
        }

        else if (levelCount != 1)
        {
            if (Input.GetMouseButtonUp(0) && remainingBallAmount != 0)
            {

                remainingBallAmount--;

            }
        }

        if (levelCount > 1)
        {
            uIController.isStart = true;
        }
    }

    void Started()
    {
        started = true;
    }
}
