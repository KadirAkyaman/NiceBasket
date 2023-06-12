using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplauseController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] List<AudioClip> applauseClip;
    int randomNumber;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ApplausePlay()
    {
        randomNumber = Random.Range(0, 6);
        audioSource.clip = applauseClip[randomNumber];
        audioSource.Play();
    }

}
