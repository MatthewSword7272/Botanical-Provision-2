using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="new Item",menuName="Inventory/Item")]
public class Item : ScriptableObject
{
     public string itemName = "itemname";
    public Sprite icon = null;
    public virtual void Use() {
        Debug.Log("Using "+itemName);
    }
   
}