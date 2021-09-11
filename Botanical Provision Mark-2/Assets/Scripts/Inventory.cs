using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 9;
    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;
    public static Inventory instance;

    void Awake()
    {

        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public List<Item> items = new List<Item>();


    public void Add(Item item)
    {
        if (items.Count <= space)
        {

            if (items.Contains(item))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].name == item.name)
                    {

                        ++items[i].itemAmount;
                        

                    }
                }
            }
            else
            {
                items.Add(item);
                item.itemAmount = 1;
            }


            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }


    }
    public void Remove(Item item)
    {
        Debug.Log("Remove Item"+items.Count);

        foreach (Item i in items) {
            Debug.Log(item.itemName);
            if (i.itemName == item.itemName)
            {
                Debug.Log("Remove Item" + i.itemName);

                items.Remove(i);

                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return;
            }
        }

    }
    public void Test() { }

}
