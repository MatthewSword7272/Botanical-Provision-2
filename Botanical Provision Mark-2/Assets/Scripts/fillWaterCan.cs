using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillWaterCan : Interactable
{
    int water = 0;

  void  Start() {
        popup.enabled = false;

    }

    public override void Interact()
    {
            base.Interact();
            water = 100;
        StartCoroutine(ShowMessage());
        Debug.Log("water");
    }


    IEnumerator ShowMessage()
    {
        popup.enabled = true;
        yield return new WaitForSeconds(5);
        popup.enabled = false;
    }




}
