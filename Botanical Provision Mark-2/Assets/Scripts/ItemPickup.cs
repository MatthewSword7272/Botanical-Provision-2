using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    public Item item;
    bool done=false;
    public override void Interact()
    {

        base.Interact();
        pick();
    }
    void pick()
    {
        FindObjectOfType<Inventory>().Add(item);
        Debug.Log("picking"+item.itemName) ;
        //add to inventory

    }
}