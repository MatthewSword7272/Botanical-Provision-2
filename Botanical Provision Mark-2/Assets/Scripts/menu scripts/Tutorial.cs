using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Canvas me;
    public Button Close;
    public Button Left;
    public Button Right;
    public Sprite[] screens = new Sprite[5];
    int index = 0;

    public void closebutton()
    {
        if (SceneManager.GetActiveScene().name == "Normal Verison" || SceneManager.GetActiveScene().name == "Showcase Scene")
        {
            gameObject.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Title Screen");
        }
    }
    public void LeftButton()
    {
        if (index > 0)
        {
            index--;
            me.GetComponent<Image>().sprite = screens[index];
        }
    }
    public void RightButton()
    {
        if (index < 4)
        {
            index++;
            me.GetComponent<Image>().sprite = screens[index];
        }
    }


}
