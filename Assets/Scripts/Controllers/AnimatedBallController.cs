using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBallController : MonoBehaviour
{

    UIController uIController;
    void Start()
    {
        uIController = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    void Update()
    {
        if (uIController.isStart)
        {
            gameObject.SetActive(false);
        }
    }


}
