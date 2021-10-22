using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    public Item itemf;
    public Item items;
    public Button Seed;
    public Button Fruit;
    public Button Close;
    private Player player;
    public GameObject water;
    private GameObject inventory;
    public bool grown = false;
    public bool firstWater = false;
    public bool secoundWater = false;
    public Animation anim;
    public GameObject _Camera;
    public CinemachineFreeLook _3rdCam;
    private Color startcolor;
    public int NumOfSeeds = 9;
    public int NumOfFruits = 9;
    private NoMore noSeedFruit;
    private GameObject pickSeedObj;
    private GameObject pickFruitObj;
    public AudioClip pickUpSound;
    public AudioClip wateringSound;
    private AudioSource audioSource;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        //  popup.enabled = false;
        water = GameObject.Find("WaterSlider");
        anim = FindObjectOfType<Animation>();
        _Camera = GameObject.Find("3rd Person Camera");
        _3rdCam = _Camera.GetComponent<CinemachineFreeLook>();
        noSeedFruit = FindObjectOfType<NoMore>();
        pickSeedObj = GameObject.Find("Pick Seed From Plant");
        pickFruitObj = GameObject.Find("Pick Fruit Or Vegetable");
        startcolor = GetComponentInChildren<Renderer>().material.color;
        audioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && grown)
        {
            Debug.Log("ripe");
            base.Interact();
            popup.enabled = true;
            secoundWater = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            anim.GatherOn();
            player.playerInPickUp = true;
            _3rdCam.enabled = false;

        }

        if (Vector2.Distance(transform.position, player.transform.position) < 3 && !grown)
        {
            Debug.Log("else if ");
            base.Interact();
            Water();
        }

    }
    void Water()
    {
        bool enough = false;
        if (water.GetComponent<Slider>().value >= 20) enough = true;
        Debug.Log("wat");
        if (firstWater == false && enough)
        {
            Debug.Log("first water ");
            audioSource.PlayOneShot(wateringSound, 1f);
            firstWater = true;
            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 20;

        }
        else if (secoundWater == false && enough)
        {
            Debug.Log("first water ");
            audioSource.PlayOneShot(wateringSound, 1f);
            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 20;

            secoundWater = true;

        }
    }


    public void SeedClicked()
    {
        if (NumOfSeeds == 0)
        {
            noSeedFruit.NoMoreStart("Plant does not have seeds");
        }
        else
        {
            FindObjectOfType<Inventory>().Add(items);
            Debug.Log("picking" + items.itemName);
            NumOfSeeds--;
            pickSeedObj.GetComponent<Toggle>().isOn = true;
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position, 1f);
        }
    }
    public void FruitClicked()
    {
        if (NumOfFruits == 0)
        {
           noSeedFruit.NoMoreStart("Plant does not have fruit");
        }
        else
        {
            FindObjectOfType<Inventory>().Add(itemf);
            Debug.Log("picking" + itemf.itemName);
            NumOfFruits--;
            pickFruitObj.GetComponent<Toggle>().isOn = true;
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position, 1f);
        }
    }
    public void CloseClicked()
    {
        popup.enabled = false;

        anim.GatherOff();
        player.playerInPickUp = false;

        if (!player.playerInInventory)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _3rdCam.enabled = true;
        }

    }

    void OnMouseEnter()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3)
        {
            if (PauseMenu.GameIsPaused == false || player.playerInInventory == false)
            {              
                GetComponentInChildren<Renderer>().material.color = Color.yellow;
            }
        }
    }
    void OnMouseExit()
    {
        GetComponentInChildren<Renderer>().material.color = startcolor;
    }

}
