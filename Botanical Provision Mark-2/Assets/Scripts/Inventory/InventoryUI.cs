using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;
    public Transform itemsParent;
    public GameObject inventoryUI;
    InventorySlot[] slots;
    private Canvas popup;
    public GameObject Camera;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start inventory ui");
        inventoryUI.SetActive(false);
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        popup = GameObject.FindGameObjectWithTag("popup").GetComponent<Canvas>();
        player = FindObjectOfType<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (inventoryUI.activeSelf)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Camera.SetActive(false);
                player.playerInInventory = true;
            }
            else
            {
                player.playerInInventory = false;

                if (player.playerInPickUp == false)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Camera.SetActive(true);                 
                }
            }
        }  

    }
    public void UpdateUI()
    {
        Debug.Log("update ui");


        foreach (Item i in inventory.items)
        {

            Debug.Log(i.itemName);
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                Debug.Log("add" + i);
                slots[i].AddItem(inventory.items[i]);


            }
            else
            {
                Debug.Log("clear" + i);
                slots[i].ClearSlot();

            }
        }
    }
}