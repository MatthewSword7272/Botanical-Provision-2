using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
public class Seed : Item
{

    public override void Use()
    {
        Debug.Log("override" + itemName);


    }
}
