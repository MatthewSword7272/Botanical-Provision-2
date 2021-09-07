using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeButton;
    public Text _amountText;
    Inventory inventory;


    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void AddItem(Item newItem) {
        if (!item)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
        }
        else
        {
            if (item != newItem)
            {
                Debug.LogWarning($"Type mismatch between current item {item} and added item {newItem}!", this);
                return;
            }

            
        }        
        _amountText.text = item.itemAmount.ToString();

    }

    public void RemoveItem(int amount = 1)
    {
        // check if enough
        if (!item)
        {
            Debug.LogWarning("This slot is empty! Can't remove", this);
            // TODO handle this?
            return;
        }

        if (item.itemAmount - amount < 0)
        {
            Debug.LogWarning($"Not enough items in this slot to remove {amount}!", this);
        }
        else
        {
            // simply reduce the amount
            item.itemAmount -= amount;

        }   
        // update the text
        _amountText.text = item.itemAmount.ToString();


        // Only if you reached 0 -> removed the last item 
        // reset this slot
        if (amount <= 0)
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }

    public void ClearSlot(){
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;


    }
    public void OnRemoveButton() {
        int amount = int.Parse(_amountText.text);
        Debug.Log("remove" + item.itemName);

        amount--;
        if ( amount == 0)
        {
            inventory.items.Remove(item);
            _amountText.text = "";
            RemoveItem();
            return;

        }
        _amountText.text = amount.ToString();
        

    }
    public void UseItem()
    { 
        if (item) {

            item.Use();


            int amount = Int32.Parse(_amountText.text);
            Debug.Log("remove" + item.itemName);

            amount--;
            if (amount == 0)
            {
                FindObjectOfType<Inventory>().Remove(item);
                _amountText.text = "";
                return;

            }
            _amountText.text = amount.ToString();



        } 
    }
}
