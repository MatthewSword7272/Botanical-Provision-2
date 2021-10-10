using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
public class Seed : Item
{
    private GameObject player;
    public GameObject TreePrefab;
    private Player playerMovement;
    private GameObject text;

    public override void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = FindObjectOfType<Player>();
        text = GameObject.Find("MessageText");

        Debug.Log("override" + itemName);

        if (playerMovement.playerInZone)
        {
            Debug.Log("Worked");
            text.GetComponent<Text>().text = "";
            Instantiate(TreePrefab, new Vector3(player.transform.position.x, 15, player.transform.position.z + 1), Quaternion.identity);
        }
        else 
        {
            Debug.Log("Player Outside Zone");
            text.GetComponent<Text>().text = "Cannot plant seed here";
            text.GetComponent<Text>().color = Color.white;

            return;
        }

   }
}
