using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

    [SerializeField] private float DayLength;
    public GameObject ClockArm;

    AudioSource audioSource;
    public AudioClip Bell;

    public int Date = 1;
    public float TimeCount = 0f;
    [SerializeField]
    bool Is_Night
    {
        get { return Is_Night; }
        set
        {   
            if (Is_Night)
            {
                BeginNight();
            }
            else
            {
                BeginDawn();
            }
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       // BeginNight();
    }
    void Update()
    {
        TimeCount += Time.deltaTime;
        CheckTime();
    }
    private void BeginNight()
    {
        audioSource.clip = Bell;
        audioSource.PlayOneShot(Bell);
    }
    private void BeginDawn()
    {

    }
    void CheckTime()
    {
        if(TimeCount >= 0.33 * DayLength && !Is_Night)
        {
            Is_Night = true;
        }
        else if(TimeCount >= DayLength && Is_Night)
        {
            Is_Night = false;
            TimeCount = 0f;
            
            if(Date==3)
            {
                EndGame();
            }
            else Date++;
        }
    }
    void EndGame()
    {
        ;
    }
}
