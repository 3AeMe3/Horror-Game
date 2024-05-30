using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    public static QuestSystem instance;

    [SerializeField] private List<Quest> quests = new List<Quest>();
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private float typingSpeed = 0.1f;
    [SerializeField] private AudioClip questStart;
    [SerializeField] private Transform soundQuestPosition;
   

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

    // M�todo para activar las misiones
    public void ActivateQuest(string questNumber)
    {
        Quest quest = GetQuestByNumber(questNumber);
        if (quest != null)
        {
            quest.isActivate = true;
            AudioSource.PlayClipAtPoint(questStart, soundQuestPosition.position,.5f);
            UpdateQuestText();
            Debug.Log($"Se activ� la misi�n: {quest.questNumber}");
        }
        else
        {
            Debug.LogWarning($"Misi�n no encontrada: {questNumber}");
        }
    }

    // M�todo para completar las misiones
    public void CompleteQuest(string questNumber)
    {
        Quest quest = GetQuestByNumber(questNumber);
        if (quest != null)
        {
            quest.isComplete = true;
            Debug.Log($"Misi�n completada: {quest.questNumber}");
            UpdateQuestText();
        }
        else
        {
            Debug.LogWarning($"Misi�n no encontrada: {questNumber}");
        }
    }

    // M�todo para obtener la mision por numero (string)
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

    // M�todo para actualizar el texto de la misi�n
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