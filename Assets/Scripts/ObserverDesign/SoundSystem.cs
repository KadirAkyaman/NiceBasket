using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : Observer
{
    [SerializeField] AudioSource groundSound;
    [SerializeField] AudioSource holeSound;
    [SerializeField] AudioSource courtSound;
    [SerializeField] AudioSource ballSound;
    [SerializeField] AudioSource swipeBallSound;
    private void Start()
    {
        ObserverManager.Instance.RegisterObserver(this, SubjectType.SoundPanel);
    }

    public override void OnNotify(NotificationType notificationType)
    {
        switch (notificationType)
        {
            case NotificationType.HitGround:
                groundSound.Play();
                break;

            case NotificationType.HitHole:
                holeSound.Play();
                break;

            case NotificationType.HitCourt:
                courtSound.Play();
                break;

            case NotificationType.HitBall:
                ballSound.Play();
                break;

            case NotificationType.SwipeBall:
                swipeBallSound.Play();
                break;

        }


    }


}
