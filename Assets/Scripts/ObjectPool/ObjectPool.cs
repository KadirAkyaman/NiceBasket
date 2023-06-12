using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Queue<GameObject> pooledBalls;
    [SerializeField] GameObject ballPrefab;
    public int poolSize;

    [SerializeField] Transform startPos;

    GameManager gameManager;
    public int remainingBall;
    UIController uIController;

    private void Awake()
    {
        pooledBalls = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject ball = Instantiate(ballPrefab);
            ball.transform.position = startPos.position;
            ball.SetActive(false);

            pooledBalls.Enqueue(ball);
        }


    }

    private void Start()
    {
        remainingBall = poolSize;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        uIController = GameObject.Find("Canvas").GetComponent<UIController>();
        if (gameManager.levelCount > 1)
        {
            remainingBall--;
            GetPooledBall();
        }
    }
    private void Update()
    {

        if (remainingBall > 0 && uIController.isStart)
        {
            if (Input.GetMouseButtonUp(0))
            {
                remainingBall--;
                Invoke("GetPooledBall", 0.2f);
            }
        }
    }


    public GameObject GetPooledBall()
    {
        if (pooledBalls.Count == 0)
        {
            return null;
        }

        GameObject ball = pooledBalls.Dequeue();

        ball.SetActive(true);

        return ball;
    }

}
