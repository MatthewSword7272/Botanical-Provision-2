using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
    // Start is called before the first frame update
    bool firstloop = true;
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
    private Renderer[] r;


    private void Start()
    {
        popup = GetComponentInChildren<Canvas>();
        player = FindObjectOfType<Player>();
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        water = GameObject.Find("WaterSlider");
        _Camera = GameObject.Find("3rd Person Camera");
        _3rdCam = _Camera.GetComponent<CinemachineFreeLook>();
        noSeedFruit = FindObjectOfType<NoMore>();
        pickSeedObj = GameObject.Find("Pick Seed From Plant");
        pickFruitObj = GameObject.Find("Pick Fruit Or Vegetable");
        r = GetComponentsInChildren<Renderer>();
        foreach (Renderer re in r)
        {
            startcolor = re.material.color;
        }
        audioSource = GetComponent<AudioSource>();
        currentNSeeds = NumOfSeeds;
    }

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
                tree.SetActive(false);
                tree1.SetActive(true);
                StartCoroutine(CoroutineA());

            }
            else if (firstloop)
            {
                firstloop = false;
                tree.SetActive(false);
                CloseClicked();
            }

        }
        if (isopen && ClickOutsideMenu())
        {
            CloseClicked();
        }

    }

    bool ClickOutsideMenu()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.currentSelectedGameObject.CompareTag("popup"))
        { 
            return true;
        }

        return false;
    }

    IEnumerator CoroutineA()
    {
        // wait for 60 second
        yield return new WaitForSeconds(60f);
        tree1.SetActive(false);
        tree.SetActive(true);
        foreach (Renderer re in r)
        {
            re.material.color = startcolor;
        }
        currentNSeeds = NumOfSeeds;
    }

    public override void Interact()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3 && grown)
        {
            base.Interact();
            popup.enabled = true;
            secoundWater = true;
            isopen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            AnimationPlayer.GatherOn(gameObject.name);
            player.playerInPickUp = true;
            _3rdCam.enabled = false;
            return;

        }

        if (Vector2.Distance(transform.position, player.transform.position) < 3 && !grown)
        {
            base.Interact();
            Water();
        }

    }
    void Water()
    {
        bool enough = false;
        if (water.GetComponent<Slider>().value >= 20) enough = true;

        if (enough)
        {

            if (firstWater == false)
            {
                firstWater = true;
            }
            else if (secoundWater == false)
            {
                secoundWater = true;
            }

            audioSource.PlayOneShot(wateringSound, 1f);
            water.GetComponent<Slider>().value = water.GetComponent<Slider>().value - 15;
            StartCoroutine(AnimationPlayer.Water());
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
            currentNSeeds--;
            pickFruitObj.GetComponent<Toggle>().isOn = true;
            AudioSource.PlayClipAtPoint(pickUpSound, gameObject.transform.position, 1f);
        }
    }
    public void CloseClicked()
    {
        popup.enabled = false;
        isopen = false;
        AnimationPlayer.GatherOff();
        player.playerInPickUp = false;

        if (!player.playerInInventory)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _3rdCam.enabled = true;
        }

    }

    void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 3 && !PauseMenu.GameIsPaused && !player.playerInInventory && !player.playerInPickUp)
        {
            foreach (Renderer re in r)
            {
                re.material.color = Color.blue;
            }
        }
    }
    void OnMouseExit()
    {
        foreach (Renderer re in r)
        {
            re.material.color = startcolor;
        }
    }

}
