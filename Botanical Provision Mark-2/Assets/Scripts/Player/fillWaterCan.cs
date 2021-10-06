using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillWaterCan : Interactable
{
    private PlayerVitals playerVitals;
    public Slider waterSlider;
    public Animation anim;


    void Start() {
        anim = FindObjectOfType<Animation>();

    }

    public override void Interact()
    {
        base.Interact();

        playerVitals = FindObjectOfType<PlayerVitals>();
        waterSlider.value += 100;
        //anim.Water()


        Debug.Log("water");
    }


   



}
