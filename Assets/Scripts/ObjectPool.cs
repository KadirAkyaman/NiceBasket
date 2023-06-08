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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Update()
    {

        if (!gameManager.isFinish)
        {
            if (Input.GetMouseButtonUp(0))
            {
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

    public void ReturnPooledBall(GameObject ball)
    {
        ball.SetActive(false); // Görünmez yap

        pooledBalls.Enqueue(ball); // Kuyruða geri ekle

        ball.transform.position = startPos.position;
    }
}
