using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPanel : Subject
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            HitGround();
        }

        if (collision.gameObject.CompareTag("Hole"))
        {
            HitHole();
        }

        if (collision.gameObject.CompareTag("Court"))
        {

            HitCourt();

        }

        if (collision.gameObject.CompareTag("Ball"))
        {
            HitBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreArea"))
        {
            Basket();
        }

        if (other.CompareTag("Target"))
        {
            HitTarget();
        }
    }


    public void HitGround()
    {
        Notify(NotificationType.HitGround);
    }

    public void HitHole()
    {
        Notify(NotificationType.HitHole);
    }

    public void HitCourt()
    {
        Notify(NotificationType.HitCourt);
    }

    public void HitBall()
    {
        Notify(NotificationType.HitBall);
    }

    public void Basket()
    {
        Notify(NotificationType.Basket);
    }

    public void HitTarget()
    {
        Notify(NotificationType.Target);
    }
}
