using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    private Vector3 minScale;
    public Vector3 maxScale;
    private Vector3 postion;
    public float speed = 2f;
    public List<Mesh> _mesh;
    public List<Material> _materials;
    public ItemPickup pick;
    int treeState = 1;
 


    // Start is called before the first frame update
    void Start()
    {
        pick = GetComponentInChildren<ItemPickup>();
        transform.localScale = new Vector3(0, 0, 0);
        minScale = transform.localScale;
        postion = transform.localPosition;
        GetComponentInChildren<MeshFilter>().mesh = _mesh[0];
        GetComponentInChildren<Renderer>().material = _materials[0];

    }

    // Update is called once per frame
    void Update()
    {

        postion = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //if  grown
        if (transform.localScale.x >= 2 && treeState == 3)
        {
            pick.grown = true;

            transform.localScale = new Vector3(2, 2, 2);
        }
        //if waiting to be watered
        else if ((treeState==1&& transform.localScale.x>1)||(treeState==2 && transform.localScale.x>2)) {
            Debug.Log("waiting to be watered");
        
        }

        //if ready to keep getting bigger
        else
        {
            //Debug.Log("tree grow 2");

            float rate = Time.deltaTime / 20;
            transform.localScale += new Vector3(rate, rate, rate);
        }


        if ((transform.localScale.x >= 1 && transform.localScale.x < 2 )&&pick.firstWater==true)
        {
            treeState = 2;
          //  Debug.Log("tree grow 3");

            GetComponentInChildren<MeshFilter>().mesh = _mesh[1];
            GetComponentInChildren<Renderer>().material = _materials[1];

        }
        else if (transform.localScale.x >= 2 && pick.secoundWater==true)
        {
            treeState = 3;
            //Debug.Log("tree grow 4");
            GetComponentInChildren<MeshFilter>().mesh = _mesh[2];
            GetComponentInChildren<Renderer>().material = _materials[2];
        }

    }
}
