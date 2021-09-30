using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    public Item itemf;
    public Item items;
    public Button Seed;
    public Button Fruit;
    public Button Close;
    public bool grown = true;
    private GameObject player;
    public TreeGrow t;
    public Slider water;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && t.grown)
        {
            base.Interact();
            popup.enabled = true;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 3 && !t.grown)
        {
            Debug.Log("else if ");
            base.Interact();
            Water(); 
        }
       
    }
    void Water() {
        bool enough=false;
        if (water.value >= 20) enough = true;
        Debug.Log("wat");
        if (t.firstWater == false&& enough)
        {
            Debug.Log("first water ");

            t.firstWater = true;
            water.value = water.value - 20;

        }
        else if (t.secoundWater == false && enough)
        {
            Debug.Log("first water ");

            water.value = water.value - 20;

            t.secoundWater = true;

        }
    }
  

    public void SeedClicked()
    {
        FindObjectOfType<Inventory>().Add(items);
        Debug.Log("picking" + items.itemName);
    }
    public void FruitClicked()
    {

        FindObjectOfType<Inventory>().Add(itemf);
        Debug.Log("picking" + itemf.itemName);
    }
    public void CloseClicked()
    {
        popup.enabled = false;
    }
}
