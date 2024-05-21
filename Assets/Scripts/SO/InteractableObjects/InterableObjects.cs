using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


[CreateAssetMenu(menuName = "HorrorGame/InteractableItem")]
public class InterableObjects : ScriptableObject
{
    public string objectName;
    public bool isOpen;
    public AudioClip openSound;
    public AudioClip tryOpen;
    public AudioClip closeSound;

    public void Open(Vector3 position)
    {
        isOpen = true;
        AudioSource.PlayClipAtPoint(openSound, position);

    }
    public void CantOpen(Vector3 position)
    {

        AudioSource.PlayClipAtPoint(tryOpen, position,.8f);

    }
    public void Close(Vector3 position)
    {
        isOpen = false;
        AudioSource.PlayClipAtPoint(openSound, position);

    }
}
