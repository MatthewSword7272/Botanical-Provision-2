using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    bool firstloop = true;
    public bool pickupEnbabled = true;
    public bool rootVeg = false;
    public Item itemf;
    public Item items;
    public Button Seed;
    public Button Fruit;
    public Button Close;
    private Player player;
    public GameObject water;
    private GameObject inventory;
    public GameObject tree, tree1;
    public bool grown = false;
    public bool firstWater = false;
    public bool secoundWater = false;
    public bool isopen = false;
    public Animation anim;
    public GameObject _Camera;
    public CinemachineFreeLook _3rdCam;
    private Color startcolor;
    public int NumOfSeeds = 5;
    public int currentNSeeds;
    private NoMore noSeedFruit;
    private GameObject pickSeedObj;
    private GameObject pickFruitObj;
    public AudioClip pickUpSound;
    public AudioClip wateringSound;
    private AudioSource audioSource;


    private void Update()
    {
        if (PauseMenu.GameIsPaused)
        {
            popup.enabled = false;

        }
        if (isopen && !PauseMenu.GameIsPaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            popup.enabled = true;
        }

        if (currentNSeeds == 0)
        {
            if (!rootVeg)
            {
                pickupEnbabled = false;
                tree.SetActive(false);
                tree1.SetActive(true);
                StartCoroutine(coroutineA());

            }
            else if (firstloop)
            {
                firstloop = false;
                tree.SetActive(false);
                pickupEnbabled = false;
                CloseClicked();
            }

        }

    }
    IEnumerator coroutineA()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(60.0f);
        tree1.SetActive(false);
        tree.SetActive(true);
        pickupEnbabled = true;
        currentNSeeds = NumOfSeeds;
    }
    private void Start()
    {
        popup = GetComponentInChildren<Canvas>();
        player = FindObjectOfType<Player>();
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        water = GameObject.Find("WaterSlider");
        anim = FindObjectOfType<Animation>();
        _Camera = GameObject.Find("3rd Person Camera");
        _3rdCam = _Camera.GetComponent<CinemachineFreeLook>();
        noSeedFruit = FindObjectOfType<NoMore>();
        pickSeedObj = GameObject.Find("Pick Seed From Plant");
        pickFruitObj = GameObject.Find("Pick Fruit Or Vegetable");
        Renderer[] r;

        r = GetComponentsInChildren<Renderer>();
        foreach (Renderer re in r)
        {
            startcolor = re.material.color;
        }
        audioSource = GetComponent<AudioSource>();
        currentNSeeds = NumOfSeeds;


    }
    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && grown && pickupEnbabled)
        {
            Debug.Log("ripe");
            base.Interact();
            popup.enabled = true;
            secoundWater = true;
            isopen = true;
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
            anim.Water();
        }
        else if (secoundWater == false && enough)
        {
            Debug.Log("first water ");
            audioSource.PlayOneShot(wateringSound, 1f);
            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 20;
            secoundWater = true;
            anim.Water();

        }
    }


    public void SeedClicked()
    {
        if (currentNSeeds == 0)
        {
            noSeedFruit.NoMoreStart("Plant does not have seeds");
        }
        else
        {
            FindObjectOfType<Inventory>().Add(items);
            Debug.Log("picking" + items.itemName);
            currentNSeeds--;
            pickSeedObj.GetComponent<Toggle>().isOn = true;
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position, 1f);
        }
    }
    public void FruitClicked()
    {
        if (currentNSeeds == 0)
        {
            noSeedFruit.NoMoreStart("Plant does not have fruit");
        }
        else
        {
            FindObjectOfType<Inventory>().Add(itemf);
            Debug.Log("picking" + itemf.itemName);
            currentNSeeds--;
            pickFruitObj.GetComponent<Toggle>().isOn = true;
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position, 1f);
        }
    }
    public void CloseClicked()
    {
        popup.enabled = false;
        isopen = false;
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
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && pickupEnbabled)
        {
            if (PauseMenu.GameIsPaused == false || player.playerInInventory == false)
            {

                Renderer[] r =
                GetComponentsInChildren<Renderer>();
                foreach (Renderer re in r)
                {
                    re.material.color = Color.yellow;
                }
            }
        }
    }
    void OnMouseExit()
    {
        Renderer[] r =
        GetComponentsInChildren<Renderer>();
        foreach (Renderer re in r)
        {
            re.material.color = startcolor;
        }
    }

}
