using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public void OnEnable()
    {
        mainMenu.SetActive(false);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
    }
}
