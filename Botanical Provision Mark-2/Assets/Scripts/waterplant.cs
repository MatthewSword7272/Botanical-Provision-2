using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterplant : Interactable
{
    void Start()
    {
        popup.enabled = false;

    }
public    TreeGrow t;
    public override void Interact()
    {
        Debug.Log("wat");
        base.Interact();
        if (t.firstWater == false)
        {
            t.firstWater = true;
            StartCoroutine(ShowMessage());

        }
        else if (t.secoundWater = false) {
            t.secoundWater = true;
            StartCoroutine(ShowMessage());

        }
    }

    IEnumerator ShowMessage()
    {
        popup.enabled = true;
        yield return new WaitForSeconds(5);
        popup.enabled = false;
    }

}
