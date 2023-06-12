using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] BallType ballType = null;

    [SerializeField] float lifeTime;

    public bool isBasket;


    Rigidbody ballRb;
    SwipeController swipeController;

    private void Start()
    {
        ScriptableObjects();

        isBasket = false;
        swipeController = GetComponent<SwipeController>();
        ballRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (swipeController.isThrow)
        {
            Invoke("ChangeSetActive", lifeTime);
        }
    }

    void ScriptableObjects()
    {
        GetComponent<MeshRenderer>().materials[0] = ballType.mainColor;
        GetComponent<MeshRenderer>().materials[1] = ballType.lineColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Court"))
        {
            isBasket = false;
        }
        GetComponent<Animator>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreArea"))
        {
            Invoke(nameof(ChangeSetActive), 1.5f);
        }
    }

    void ChangeSetActive()
    {
        gameObject.SetActive(false);
    }

}
