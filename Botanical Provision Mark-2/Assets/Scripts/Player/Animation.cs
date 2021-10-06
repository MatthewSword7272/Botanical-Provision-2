using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
            anim.SetBool("Run", false);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
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

    public void GatherOn()
    {
        anim.SetBool("Gathering", true);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", false);
    }

    public void GatherOff()
    {
        anim.SetBool("Gathering", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Idle", true);
    }

    public void Water()
    {
        anim.SetBool("Water", true);
    }
}
