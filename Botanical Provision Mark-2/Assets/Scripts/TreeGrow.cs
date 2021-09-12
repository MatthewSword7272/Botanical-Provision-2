using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrow : MonoBehaviour
{
    private Vector3 minScale;
    public Vector3 maxScale;
    private Vector3 postion;
    public float speed = 2f;
    public float duration = 5f;
    public List<Mesh> _mesh;
    public List<Material> _materials;


    // Start is called before the first frame update
    void Start()
    {
        minScale = transform.localScale;
        postion = transform.localPosition;
        GetComponent<MeshFilter>().mesh = _mesh[0];
        GetComponent<Renderer>().material = _materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        postion = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if (transform.localScale.x >= 2)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            float rate = Time.deltaTime / 20;
            transform.localScale += new Vector3(rate, rate, rate);
        }


        if (transform.localScale.x >= 1 && transform.localScale.x < 2)
        {
            GetComponent<MeshFilter>().mesh = _mesh[1];
            GetComponent<Renderer>().material = _materials[1];

        }
        else if (transform.localScale.x >= 2 && transform.localScale.x < 2)
        {
            GetComponent<MeshFilter>().mesh = _mesh[2];
            GetComponent<Renderer>().material = _materials[2];

        }

    }
}
