using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "itemname";
    public Sprite icon = null;
    public bool itemDefault = false;
    public int itemAmount = 1;
    public int maxStack = 9;

    public virtual void Use()
    {
        

    }

}
