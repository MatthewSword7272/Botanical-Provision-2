using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Fruit", menuName = "Inventory/Fruit")]

public class Fruit : Item
{
    private PlayerVitals playerVitals;

    public override void Use()
    {

        Debug.Log("override" + itemName);
        AddHealth(itemName);

    }

    public void AddHealth(string fruit)
    {
        playerVitals = FindObjectOfType<PlayerVitals>();

        if (fruit == "Berry")
        {
            playerVitals.healthSlider.value += 25;
            playerVitals.hungerSlider.value += 25;
        }
        else if (fruit == "Banana")
        {
            playerVitals.healthSlider.value += 50;
            playerVitals.hungerSlider.value += 50;

        }
    }

}
