using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class insideHouse : MonoBehaviour
{
    
    [SerializeField] private AudioSource musicSound;

    private float minVolume = 0.1f;
    private float maxVolume = .8f;




    public bool inside;
    public bool outside;

    bool canDownAudio;
    bool canUpAudio;
    float timer;


    
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

                //Debug.Log("volume" + musicSound.volume);
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
/*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("este we tiene el player");
            if (inside)
            {
                player.currentLocation = Location.insideHouse;

                canDownAudio = true;
                canUpAudio = false;
               
            }
            if (outside)
            {
                player.currentLocation = Location.outsideHouse;
                canUpAudio = true;
                canDownAudio = false;


            }

        }

    }
*/



}
