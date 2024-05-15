using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;

    [SerializeField] List<Quest> quests = new List<Quest>();
    [SerializeField] TextMeshProUGUI questText;
    [SerializeField] float typingSpeed = 0.1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para activar misión
    public void ActivateQuest(string questNumber)
    {
        Quest quest = GetQuestByNumber(questNumber);
        if (quest != null)
        {
            quest.isActivate = true;
            UpdateQuestText();
            Debug.Log($"Se activó la misión: {quest.questNumber}");
        }
        else
        {
            Debug.LogWarning($"Misión no encontrada: {questNumber}");
        }
    }

    // Método para completar misión
    public void CompleteQuest(string questNumber)
    {
        Quest quest = GetQuestByNumber(questNumber);
        if (quest != null)
        {
            quest.isComplete = true;
            Debug.Log($"Misión completada: {quest.questNumber}");
            UpdateQuestText();
        }
        else
        {
            Debug.LogWarning($"Misión no encontrada: {questNumber}");
        }
    }

    // Método para obtener una misión por número
    private Quest GetQuestByNumber(string questNumber)
    {
        foreach (Quest quest in quests)
        {
            if (quest.questNumber == questNumber)
            {
                return quest;
            }
        }
        return null;
    }

    // Método para actualizar el texto de la misión
    private IEnumerator UpdateQuestTextCoroutine(string newText)
    {
        string displayText = "";
        foreach (char character in newText)
        {
            displayText += character;
            questText.text = displayText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void UpdateQuestText()
    {
        
        string newText = "";
        foreach (Quest quest in quests)
        {
            if (quest.isActivate && !quest.isComplete)
            {
                newText += quest.questDescription;

            }
           
        }
        StartCoroutine(UpdateQuestTextCoroutine(newText));

    }
}

[System.Serializable]
public class Quest
{
    public string questNumber;
    public string questDescription;
    public bool isActivate;
    public bool isComplete;
}