using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 9;
    public delegate void onItemChanged();
    public onItemChanged onItemChangedCallback;
    public static Inventory instance;
    void Awake() {
        if (instance != null) {
            return;
        }
        instance = this;
    }
    public List<Item> items = new List<Item>();
    public void Add(Item item) {

        if (items.Count<= space)
        {

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

    }
    public void Remove(Item item) {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    public void test() { }

}
