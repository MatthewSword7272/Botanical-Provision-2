using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fillWaterCan : Interactable
{
    private PlayerVitals playerVitals;
    public Slider waterSlider;
    public Animation anim;
    private GameObject WaterPickObj;


    void Start() {
        anim = FindObjectOfType<Animation>();
        WaterPickObj = GameObject.Find("Pick Up Water");
    }

    public override void Interact()
    {
        base.Interact();

        playerVitals = FindObjectOfType<PlayerVitals>();
        waterSlider.value += 100;
        WaterPickObj.GetComponent<Toggle>().isOn = true;
    }


   



}
