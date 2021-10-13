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
    private Player player;
    public GameObject water;
    private GameObject inventory;
    public bool grown = false;
    public bool firstWater = false;
    public bool secoundWater = false;
    public Animation anim;
    public GameObject Camera;
    private Color startcolor;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        inventory = GameObject.FindGameObjectWithTag("Inventory");
      //  popup.enabled = false;
        water = GameObject.Find("WaterSlider");
        anim = FindObjectOfType<Animation>();
        Camera = GameObject.FindGameObjectWithTag("3rdPersonCam");
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && grown)
        {
            Debug.Log("ripe");
            base.Interact();
            popup.enabled = true;
            secoundWater = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            anim.GatherOn();
            player.playerInPickUp = true;
            Camera.SetActive(false);

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
        if (inventory.activeSelf)
        {
            anim.GatherOff();
            player.playerInPickUp = false;
            inventory.SetActive(false);
            if (player.playerInInventory == false)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;               
                Camera.SetActive(true);
            }
        }
    }
 
    void OnMouseEnter()
    {
        if (PauseMenu.GameIsPaused == false || inventory.activeSelf == false)
        {
            startcolor = GetComponentInChildren<Renderer>().material.color;
            GetComponentInChildren<Renderer>().material.color = new Color(255, 128, 0, 255);
        }
    }
    void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = startcolor;
    }

}
