using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Fruit", menuName = "Inventory/Fruit")]

public class Fruit : Item
{
    private PlayerVitals playerVitals;

    public override void Use()
    {
        AddHealth(itemName);
    }

    public void AddHealth(string fruit)
    {
        playerVitals = FindObjectOfType<PlayerVitals>();

        if (fruit == "Berry Fruit")
        {
            playerVitals.healthSlider.value += 10;
            playerVitals.hungerSlider.value += 10;
        }
        else if (fruit == "Apple Fruit")
        {
            playerVitals.healthSlider.value += 15;
            playerVitals.hungerSlider.value += 15;
        }
        else if (fruit == "Carrot Veg")
        {
            playerVitals.healthSlider.value += 20;
            playerVitals.hungerSlider.value += 20;
        }
        else if (fruit == "Lettuce Veg")
        {
            playerVitals.healthSlider.value += 25;
            playerVitals.hungerSlider.value += 25;
        }
        else if (fruit == "Corn Veg")
        {
            playerVitals.healthSlider.value += 17;
            playerVitals.hungerSlider.value += 17;
        }
    }

}
