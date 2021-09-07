using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    public Item itemf;
    public Item items;
    readonly bool done=false;
    public Button Seed;
    public Button Fruit;
    public Button Close;
    
    public override void Interact()
    {

        base.Interact();
        Pick();
    }
    void Pick()
    {


        popup.enabled = true;



      
        //add to inventory
        

    }
    public void SeedClicked() {

        FindObjectOfType<Inventory>().Add(items);
        Debug.Log("picking" + items.itemName);
    }
    public void FruitClicked()
    {

        FindObjectOfType<Inventory>().Add(itemf);
        Debug.Log("picking" + itemf.itemName);
    }
    public void CloseClicked() {
        popup.enabled = false;


    }
}
