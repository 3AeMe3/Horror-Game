using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableQuest : MonoBehaviour
{
    public string QuestActivate = "";
    public string QuestComplete = "";
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                QuestSystem.instance.CompleteQuest(QuestComplete);
                QuestSystem.instance.ActivateQuest(QuestActivate);
                gameObject.SetActive(false);

            }
        }
    }

}