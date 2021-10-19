using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NoMore : MonoBehaviour
{
    private Text text;
    private void Start()
    {
        text = GameObject.Find("MessageText").GetComponent<Text>();
    }

    public void NoMoreStart(string message)
    {
        StartCoroutine(_NoMore(message));
    }

    private IEnumerator _NoMore(string message)
    {
        text.color = Color.white;
        text.text = message;
        yield return new WaitForSeconds(3);
        text.text = "";

    }
}
