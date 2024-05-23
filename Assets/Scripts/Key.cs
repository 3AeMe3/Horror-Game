using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public ItemsSO keyItem;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.TryGetComponent<Player>(out Player player))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                gameObject.SetActive(false);
                player.haveKey = true;
            }

        }

    }
  
}
