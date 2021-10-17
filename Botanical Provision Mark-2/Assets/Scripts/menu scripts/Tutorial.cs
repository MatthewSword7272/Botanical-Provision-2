using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public PauseMenu p;
    public bool fromGame;
    public Canvas me;
    public Button Close, Left, Right;
    public Sprite[] screens = new Sprite[5];
    int index=0;
    public void closebutton() {
        if (fromGame){ me.enabled = false; }
        else SceneManager.LoadScene("Title Screen");

    }
    public void LeftButton() {
        if (index> 0) {
                index--;
                me.GetComponent<Image>().sprite = screens[index];
            }
    }
    public void RightButton() {
        if (index < 4)
        {
            index++;
            me.GetComponent<Image>().sprite = screens[index];
        }
    }


}
