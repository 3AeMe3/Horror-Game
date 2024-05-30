using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class insideHouse : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSound;

    [Header("Parametros Sonido")]
   [SerializeField]private float minVolume = 0.1f;
    [SerializeField] private float maxVolume = .8f;



    [Header("Booleans")]
    public bool inside;
    public bool outside;
    private bool canDownAudio;
    private bool canUpAudio;


    private float timer;


    
    private void Start()
    {
        timer = 0f;

    }


    private void Update()
    {
        if (canDownAudio)
        {
            DownVolume();

        }

        if (canUpAudio)
        {

            UpVolume();

        }
    }



    void DownVolume()
    {

        if (musicSound.volume > minVolume)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);

            if (timer >= 3f)
            {
                musicSound.volume -= 0.1f;
                timer = 0f;

  
            }

        }
        else
        {
            canDownAudio = false;
        }
    }

    void UpVolume()
    {
        if (musicSound.volume < maxVolume)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                musicSound.volume += 0.1f;
                timer = 0f;

                
            }
        }
        else
        {
            canUpAudio = false;
        }
    }
}
