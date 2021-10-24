using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeGrow : MonoBehaviour
{
    private Vector3 minScale;
    private Vector3 postion;
    public float speed;
    public List<Mesh> _mesh;
    public List<Material> _materials;
    public ItemPickup pick;

    public bool doneGrowing = false;
    int treeState = 1;
    private GameObject WaterPlantObj;
    private AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        pick = GetComponentInChildren<ItemPickup>();
        transform.localScale = new Vector3(0, 0, 0);
        minScale = transform.localScale;
        postion = transform.localPosition;
        GetComponentInChildren<MeshFilter>().mesh = _mesh[0];
        GetComponentInChildren<Renderer>().material = _materials[0];
        WaterPlantObj = GameObject.Find("Water Growing Plant");
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        postion = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //if  grown
        if (transform.localScale.x >= 2 && treeState == 3)
        {

            pick.grown = true;
            audioSource.Stop();
            transform.localScale = new Vector3(2, 2, 2);
        }
        //if waiting to be watered
        else if ((treeState == 1 && transform.localScale.x > 1) || (treeState == 2 && transform.localScale.x > 2))
        {
            audioSource.Stop();
            Debug.Log("waiting to be watered");

        }
        //if ready to keep getting bigger
        else
        {
            //Debug.Log("tree grow 2");

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Playing");
            }

            float rate = Time.deltaTime / speed;
            transform.localScale += new Vector3(rate, rate, rate);
        }


        if ((transform.localScale.x >= 1 && transform.localScale.x < 2) && pick.firstWater == true)
        {
            treeState = 2;
            //  Debug.Log("tree grow 3");

            GetComponentInChildren<MeshFilter>().mesh = _mesh[1];
            GetComponentInChildren<Renderer>().material = _materials[1];

        }
        else if (transform.localScale.x >= 2 && pick.secoundWater == true && !doneGrowing)
        {
            treeState = 3;
            doneGrowing = true;
            GetComponentInChildren<MeshFilter>().mesh = _mesh[2];
            GetComponentInChildren<Renderer>().material = _materials[2];
            WaterPlantObj.GetComponent<Toggle>().isOn = true;
        }

        if (PauseMenu.GameIsPaused && audioSource.isPlaying)
        {
            audioSource.Stop();

        }

    }
}
