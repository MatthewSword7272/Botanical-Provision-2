using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Seed", menuName = "Inventory/Seed")]
public class Seed : Item
{
    private GameObject player;
     private GameObject moss;
    private Ray ray;
    private RaycastHit hit;
    public GameObject TreePrefab;


    public override void Use()
    {
        Debug.Log("override" + itemName);
        player = GameObject.FindGameObjectWithTag("Player");
        moss = GameObject.FindGameObjectWithTag("Plantable");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {

            Instantiate(TreePrefab, new Vector3(player.transform.position.x, 15, player.transform.position.z + 1), Quaternion.identity);
        }

    }
}
