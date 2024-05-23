using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public  class EnableQuest : MonoBehaviour
{
    [SerializeField]public string QuestActivate = "";
    [SerializeField]public string QuestComplete = "";

    [SerializeField] GameObject Key;

    [SerializeField] private GameObject introCamera;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                QuestSystem.instance.CompleteQuest(QuestComplete);
                QuestSystem.instance.ActivateQuest(QuestActivate);

                if(Key != null)
                {
                    if (!Key.activeSelf)
                    {
                        Key.SetActive(true);
                        introCamera.SetActive(false);   

                    }
                }
               
                gameObject.SetActive(false);
                //Debug.Log(gameObject.name);

            }
        }
    }

 
}