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
    public TreeGrow t;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 & grown)
        {
            base.Interact();
            popup.enabled = true;
        }
        else
        {
            waterplant();
        }
    }
    public void waterplant() {

        Debug.Log("wat");
        base.Interact();
        if (t.firstWater == false)
        {
            t.firstWater = true;
            StartCoroutine(ShowMessage());

        }
        else if (t.secoundWater == false)
        {
            t.secoundWater = true;
            StartCoroutine(ShowMessage());

        }
    }

    IEnumerator ShowMessage()
    {
        popup.enabled = true;
        yield return new WaitForSeconds(5);
        popup.enabled = false;
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
