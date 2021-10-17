using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoSeedFruit : MonoBehaviour
{
    private GameObject text;
    private void Start()
    {
        text = GameObject.Find("MessageText");
    }

    public IEnumerator NoMore(string message)
    {
        text.GetComponent<Text>().color = Color.white;
        text.GetComponent<Text>().text = message;
        yield return new WaitForSeconds(4f);
        text.GetComponent<Text>().text = "";

    }
}
