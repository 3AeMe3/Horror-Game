using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{

    [SerializeField] private GameObject flashLight;
     public bool haveKey;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Activa la linterna

            if (!flashLight.gameObject.activeSelf)
            {
                flashLight.SetActive(true);

            }
            else
            {
                flashLight.SetActive(false);

            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
       

    }

}
