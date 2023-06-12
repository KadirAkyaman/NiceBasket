using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    #region Singelton   

    static ObserverManager _instance = null;

    public static ObserverManager Instance => _instance;

    #endregion

    List<Subject> _subjects = null;

    private void Awake()
    {
        _instance = this;
    }

    public void RegisterSubject(Subject subject)
    {
        if (_subjects == null)
        {
            _subjects = new List<Subject>();
        }

        _subjects.Add(subject);
    }

    public void RegisterObserver(Observer observer, SubjectType subjectType)
    {
        foreach (var subject in _subjects)
        {
            if (subject.SubjectType == subjectType)
            {
                subject.RegisterObserver(observer);
            }
        }
    }

}

public enum NotificationType
{
    HitGround,
    HitHole,
    HitCourt,
    HitBall,
    SwipeBall
}

public enum SubjectType
{
    SoundPanel
}