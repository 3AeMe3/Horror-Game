using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject keyPrefab;
    public bool canOpenDoor;

    [HideInInspector]
    public bool doorOpen;

    Animator[] animators;



    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();    
    }
    private void Update()
    {
        if (doorOpen)
        {
            for (int i = 0; i < animators.Length; i++)
            {

                animators[i].Play("Open");
     
            }
            QuestSystem.instance.CompleteQuest("2");
            QuestSystem.instance.ActivateQuest("3");

            doorOpen = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(keyPrefab != null)
        {
            if (!keyPrefab.activeSelf)
            {
                keyPrefab.SetActive(true);
            }
        }
    }



}
