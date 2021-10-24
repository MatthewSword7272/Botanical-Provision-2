using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Item item;
    public Button removeButton;
    public Text _amountText;
    Inventory inventory;
    private Player player;
    public AudioSource audioSource;
    public AudioClip plantingSound;
    private new Animation animation;

    private void Start()
    {
        inventory = Inventory.instance;
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
        animation = FindObjectOfType<Animation>();
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
        removeButton.interactable = true;
        
        _amountText.text = item.itemAmount.ToString();
    }

    public void RemoveItem(int amount = 1)
    {
        // check if enough
        if (!item)
        {
            return;
        }

        if (item.itemAmount - amount <= 0)
        {
            inventory.Remove(item);

            //   ClearSlot();
            return;
        }
        else
        {
            // simply reduce the amount
            item.itemAmount -= amount;

        }
        // update the text
        _amountText.text = item.itemAmount.ToString();
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        _amountText.text = "";

    }
    public void OnRemoveButton()
    {
        RemoveItem();
    }

    public void UseItem()
    {
        if (item)
        {
            item.Use();
            

            if (item.itemName.Contains("Fruit") || item.itemName.Contains("Veg"))
            {
                audioSource.Play();
                animation.Eat();
                RemoveItem();
                return;
            }
            if (player.playerInZone || !item.itemName.Contains("Seed"))
            {                
                animation.Plant();
                audioSource.PlayOneShot(plantingSound, 1f);
                RemoveItem();
                return;
            }

        }
    }
}