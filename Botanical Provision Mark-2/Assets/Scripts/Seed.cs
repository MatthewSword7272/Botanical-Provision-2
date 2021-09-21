using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
public class Seed : Item
{
    private GameObject player;
    public GameObject TreePrefab;

    public override void Use()
    {
        Debug.Log("override" + itemName);
        player = GameObject.FindGameObjectWithTag("Player");

        Instantiate(TreePrefab, new Vector3(player.transform.position.x, 0, player.transform.position.z + 16), Quaternion.identity);

    }
}
