using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip[] soundDoors;
    public AudioClip[] steps;


    public AudioClip music;
    AudioSource audioSource;




    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();  
       // audioSource.clip = music;
    }
    private void Start()
    {
        audioSource.clip = music;
        audioSource.Play();
    }


    



}
