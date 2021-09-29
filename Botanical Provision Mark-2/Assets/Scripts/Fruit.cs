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
            playerVitals.healthSlider.value += 10;
            playerVitals.hungerSlider.value += 10;
        }
        else if (fruit == "Banana")
        {
            playerVitals.healthSlider.value += 30;
            playerVitals.hungerSlider.value += 30;

        }
        else if (fruit == "Apple Table")
        {
            playerVitals.healthSlider.value += 15;
            playerVitals.hungerSlider.value += 15;
        }
        else if (fruit == "Carrot Patch")
        {
            playerVitals.healthSlider.value += 20;
            playerVitals.hungerSlider.value += 20;
        }
        else if (fruit == "Lettuce Patch")
        {
            playerVitals.healthSlider.value += 25;
            playerVitals.hungerSlider.value += 25;
        }
    }

}
