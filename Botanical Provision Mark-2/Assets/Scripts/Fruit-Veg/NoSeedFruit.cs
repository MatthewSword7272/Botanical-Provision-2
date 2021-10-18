using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoSeedFruit : MonoBehaviour
{
    private GameObject text;
    private void Start()
    {
        text = GameObject.Find("MessageText");
    }

    public void NoMoreStart(string message)
    {
        StartCoroutine(NoMore(message));
    }

    private IEnumerator NoMore(string message)
    {
        text.GetComponent<Text>().color = Color.white;
        text.GetComponent<Text>().text = message;
        yield return new WaitForSeconds(3);
        text.GetComponent<Text>().text = "";

    }
}
