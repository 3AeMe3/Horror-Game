using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Playables;



public enum StatesGame
{
    none,
    inGame,
    menu,
    pause,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public StatesGame currentState = StatesGame.menu;
    [SerializeField] PlayableDirector cinematic;
    



    public GameObject ui_Quest;
    public GameObject ui_Menu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }

    }

    private void Start()
    {
        currentState = StatesGame.menu;

    }
    public void StartGame()
    {
        currentState = StatesGame.inGame;
        cinematic.Play();
        

        //cinemachine.Priority = 0;
    }

    private void Update()
    {

       
        switch (currentState)
        {
            case StatesGame.none:
                break;
            case StatesGame.inGame:
               
                ui_Menu.SetActive(false);


                break;
            case StatesGame.menu:
              
                ui_Quest.SetActive(false);
                break;
            case StatesGame.pause:
                break;
            case StatesGame.gameOver:
                break;
        }

    }




}
