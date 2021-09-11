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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start inventory ui");
        inventoryUI.SetActive(false);
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }


    }
    public void UpdateUI()
    {
        Debug.Log("update ui");


        foreach (Item i in inventory.items){

            Debug.Log(i.itemName);
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                Debug.Log("add"+i);
                slots[i].AddItem(inventory.items[i]);
          

            }
            else  {
                Debug.Log("clear" + i);
                slots[i].ClearSlot();

            }



        }
    }
}