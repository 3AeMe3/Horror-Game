using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class insideHouse : MonoBehaviour
{
    [SerializeField] AudioSource musicSound;
    float minVolume = 0.1f;
    float maxVolume = 1f;




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

        if (canDownAudio)
        {
            if(musicSound.volume != 1)
            {
                UpVolume();
            }
        }


    }



    void DownVolume()
    {
        timer += Time.deltaTime;

        if (musicSound.volume > minVolume)
        {

            if (timer > 3f)
            {
                musicSound.volume -= 0.1f;
                //Debug.Log("volume" + musicSound.volume);
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
        timer += Time.deltaTime;

        if (musicSound.volume < maxVolume)
        {

            if (timer > 3f)
            {
                musicSound.volume += 0.1f;
                    //Debug.Log("volume" + musicSound.volume);
                timer = 0f;
            }
        }
        else
        {
            canUpAudio = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
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




}
