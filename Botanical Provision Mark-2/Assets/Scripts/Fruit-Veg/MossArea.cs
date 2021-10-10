using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossArea : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider colliderPlayer)
    {
        if (colliderPlayer.gameObject.tag == "Player")
        {
            colliderPlayer.GetComponent<Player>().playerInZone = true;
            
        }
        
    }

    private void OnTriggerExit(Collider colliderPlayer)
    {
        if (colliderPlayer.gameObject.tag == "Player")
        {
            colliderPlayer.GetComponent<Player>().playerInZone = false;

        }
    }
}
