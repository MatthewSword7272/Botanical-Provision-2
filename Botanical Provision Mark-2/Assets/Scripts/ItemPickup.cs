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
    public GameObject water;
    public bool grown = false;
    public bool firstWater = false;
    public bool secoundWater = false;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
     
      //  popup.enabled = false;
        water = GameObject.Find("WaterSlider");
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && grown)
        {
            Debug.Log("ripe");
            base.Interact();
            popup.enabled = true;
            secoundWater = true;

        }

        if (Vector2.Distance(transform.position, player.transform.position) < 3 && !grown)
        {
            Debug.Log("else if ");
            base.Interact();
            Water(); 
        }
       
    }
    void Water() {
        bool enough=false;
        if (water.GetComponent<Slider>().value >= 20) enough = true;
        Debug.Log("wat");
        if (firstWater == false&& enough)
        {
            Debug.Log("first water ");

            firstWater = true;
            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 20;

        }
        else if (secoundWater == false && enough)
        {
            Debug.Log("first water ");

            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 20;

            secoundWater = true;

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
