using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeButton;
    int _amount;
    public Text _amountText;


    public void AddItem(Item newItem, int amount = 1) {
        if (!item)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
            removeButton.interactable = true;
            _amount = amount;
        }
        else
        {
            if (item != newItem)
            {
                Debug.LogWarning($"Type mismatch between current item {item} and added item {newItem}!", this);
                return;
            }

            _amount += amount;
        }
        _amountText.text = _amount.ToString();

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

        if (_amount - amount < 0)
        {
            Debug.LogWarning($"Not enough items in this slot to remove {amount}!", this);
        }

        // simply reduce the amount
        _amount -= amount;
        // update the text
        _amountText.text = amount.ToString();

        // Only if you reached 0 -> removed the last item 
        // reset this slot
        if (amount == 0)
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
        Debug.Log("remove" + item.itemName);
        FindObjectOfType<Inventory>().Remove(item);


    }
    public void UseItem()
    { 
        if (item) {

            item.Use();
        
        } 
    }
}
