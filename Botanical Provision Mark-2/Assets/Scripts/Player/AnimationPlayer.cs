using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    Animator anim;
    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.playerInInventory && !player.playerInPickUp)
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }
            if (!Input.anyKey && (!anim.GetCurrentAnimatorStateInfo(0).IsName("Watering") || !anim.GetCurrentAnimatorStateInfo(0).IsName("Planting 02")))
            {              
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && anim.GetBool("Walk"))
            {
                anim.SetBool("Run", true);
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", false);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("Run", false);
                anim.SetBool("Walk", true);
                anim.SetBool("Idle", false);

            }
        }
      
    }

    public void GatherOn(string treename)
    {

        if (treename.Contains("Apple") || treename.Contains("Corn"))
        {
            anim.SetBool("Gathering Standing", true);
        }
        else
        {
            anim.SetBool("Gathering Kneeling", true);
        } 
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
    }

    public void GatherOff()
    {
        anim.SetBool("Gathering Standing", false);
        anim.SetBool("Gathering Kneeling", false);
        anim.SetBool("Run", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
    }

    public void Water()
    {
        if (Input.GetMouseButton(1))
        {
            anim.SetBool("Idle", false);
            anim.SetTrigger("Watering");
        }   
    }

    public void Eat()
    {
        anim.SetBool("Idle", false);
        anim.Play("Eat");
    }

    public void Plant()
    {
        anim.SetBool("Idle", false);
        anim.Play("Planting 02");
    }
}
