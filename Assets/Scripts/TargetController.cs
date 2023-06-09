using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ScoreController scoreController;
    [SerializeField] Collider targetCollider;
    [SerializeField] Animator targetAnimator;
    [SerializeField] GameObject targetParent;

    bool isHit;
    void Start()
    {
        isHit = false;
        targetParent.transform.position = new Vector3(targetParent.transform.position.x, targetParent.transform.position.y, -9.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("hit");
            isHit = true;
            scoreController.score++;
            scoreController.ScoreUpdate();
            targetAnimator.SetBool("isHit", true);
            targetCollider.enabled = false;
        }
    }


    void Update()
    {
        targetParent.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z >= 9.5f)
        {
            if (isHit)
            {
                targetParent.SetActive(false);
            }
            else
            {
                targetParent.transform.position = new Vector3(targetParent.transform.position.x, targetParent.transform.position.y, -9.5f);
            }

        }
    }
}
