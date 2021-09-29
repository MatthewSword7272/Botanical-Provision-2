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
    private GameObject player;
    private TreeGrow treegrow;
    public Slider water;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        treegrow = FindObjectOfType<TreeGrow>();
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && treegrow.grown)
        {
            base.Interact();
            popup.enabled = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < 3 && !treegrow.grown)
        {
            Debug.Log("else if ");
            base.Interact();
            Water(); 
        }
       
    }
    void Water() {
        bool enough=false;
        if (water.value >= 20)
        {
            enough = true;
        }
        Debug.Log("wat");
        if (treegrow.firstWater == false&& enough)
        {
            Debug.Log("first water ");

            treegrow.firstWater = true;
            water.value = water.value - 20;

        }
        else if (treegrow.secoundWater == false && enough)
        {
            Debug.Log("first water ");

            water.value = water.value - 20;

            treegrow.secoundWater = true;

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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
