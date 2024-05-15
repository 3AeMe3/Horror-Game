using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] Transform player;
    //public bool hasKey;

    
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<Player>(out Player player))
        {
            player.haveKey = true;
           
        }
    }
}
