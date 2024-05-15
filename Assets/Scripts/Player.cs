using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Location
{
    insideHouse,
    outsideHouse,

}
public class Player : MonoBehaviour
{
    public bool haveKey;
    public Location currentLocation = Location.outsideHouse;



    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Door>(out Door door))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (door.canOpenDoor && haveKey)
                {
                    AudioSource.PlayClipAtPoint(SoundManager.instance.soundDoors[0], transform.position, 0.7f);
                    door.doorOpen = true;


                }
                else
                {
                    AudioSource.PlayClipAtPoint(SoundManager.instance.soundDoors[1], transform.position, 0.7f);
                    GameManager.instance.ui_Quest.SetActive(true);
                }
            }
        }



    }

}
