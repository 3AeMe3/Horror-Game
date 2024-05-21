using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator[] doorAnimation;
    public InterableObjects interableObjects;


    private const string openDoor = "OpenDoor";

    //bool activateDoor ;
    public bool needKey;
    bool openDoorEnabled;
    private void Start()
    {
        doorAnimation = GetComponentsInChildren<Animator>();

        //openDoorEnabled = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
           

            if (!needKey)
            {
                if (Input.GetKeyDown(KeyCode.E) && !openDoorEnabled)
                {
                    interableObjects.Open(transform.position);
                    OpenDoorAnimation();

                    openDoorEnabled = true; // Marcamos que la puerta está abierta
                }
                else if (Input.GetKeyDown(KeyCode.E) && openDoorEnabled)
                {
                    CloseDoorAnimation();
                    openDoorEnabled = false; // Marcamos que la puerta está cerrada
                }
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interableObjects.CantOpen(transform.position);
                    GameManager.instance.ui_Quest.SetActive(true);
                    

                }
            }


        }

    }

    private void OpenDoorAnimation()
    {
        //Debug.Log("animacion activada");
        for (int i = 0; i < doorAnimation.Length; i++)
        {
            doorAnimation[i].SetBool(openDoor, true);

        }
    }

    private void CloseDoorAnimation()
    {
        for (int i = 0; i < doorAnimation.Length; i++)
        {
            doorAnimation[i].SetBool(openDoor, false);

        }
    }
    #region
    /*public GameObject keyPrefab;
    public bool canOpenDoor;

    [HideInInspector]
    public bool doorOpen;

    Animator[] animators;


    private const string openDoorAnim = "OpenDoor";
   
    private void Awake()
    {
        animators = GetComponentsInChildren<Animator>();    
    }
    private void Start()
    {

    }
    private void Update()
    {
        if (doorOpen )
        {
            for (int i = 0; i < animators.Length; i++)
            {

                animators[i].SetBool(openDoorAnim, true);
                
     
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
    }*/
    #endregion



}
