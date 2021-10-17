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
    private NoSeedFruit noSeedFruit;

    public override void Use()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = FindObjectOfType<Player>();
        noSeedFruit = FindObjectOfType<NoSeedFruit>();


        if (playerMovement.playerInZone)
        {
            Instantiate(TreePrefab, new Vector3(player.transform.position.x, 15, player.transform.position.z + 1), Quaternion.identity);
        }
        else 
        {
            noSeedFruit.NoMoreStart("Cannot plant seed here");
            return;
        }

   }
}
