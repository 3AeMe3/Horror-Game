using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HorrorGame/Item")]

public class ItemsSO : ScriptableObject
{
    public string itemName;
    public string description;


    public Sprite icon;
    GameObject itemPrefab;
  
}
