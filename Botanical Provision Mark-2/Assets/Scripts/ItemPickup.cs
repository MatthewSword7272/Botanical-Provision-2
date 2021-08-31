using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    public Item item;
    readonly bool done=false;
    public override void Interact()
    {

        base.Interact();
        Pick();
    }
    void Pick()
    {
        FindObjectOfType<Inventory>().Add(item);
        Debug.Log("picking"+item.itemName) ;
        //add to inventory

    }
}
