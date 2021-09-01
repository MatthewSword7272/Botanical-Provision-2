using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        inventory = FindObjectOfType<Inventory>();
        inventory.onItemChangedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        
    }
    void UpdateUI() {
        Debug.Log("update ui");
        for (int i=0; i < slots.Length;i++) {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else {
                slots[i].ClearSlot();
            }
        }
    }
}